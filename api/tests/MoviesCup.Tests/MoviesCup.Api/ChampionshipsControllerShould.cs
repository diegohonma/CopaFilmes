using Microsoft.AspNetCore.Mvc;
using MoviesCup.Api.Controllers;
using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Models;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MoviesCup.Tests.MoviesCup.Api
{
    internal class ChampionshipsControllerShould
    {
        private ICreateChampionshipService _createChampionshipService;
        private ChampionshipsController _championshipsController;

        [SetUp]
        public void SetUp()
        {
            _createChampionshipService = Substitute.For<ICreateChampionshipService>();
            _championshipsController = new ChampionshipsController(_createChampionshipService);
        }

        [Test]
        public async Task ReturnBadRequestWhenChampionshipIsNull()
        {
            const string expectedError = "Não foi possível criar o campeonato.";

            _createChampionshipService
                .CreateChampionship(Arg.Any<List<MovieModel>>())
                .ReturnsNull();

            var response = await _championshipsController.CreateChampionship(Arg.Any<List<MovieModel>>()).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                var actionResult = ((BadRequestObjectResult)response.Result);
                Assert.AreEqual((int)HttpStatusCode.BadRequest, actionResult.StatusCode);
                Assert.AreEqual(expectedError, actionResult.Value.ToString());
            });
        }

        [Test]
        public async Task ReturnOkWhenChampionshipIsCreated()
        {
            _createChampionshipService
                .CreateChampionship(Arg.Any<List<MovieModel>>())
                .Returns(new ChampionshipModel(new List<ChampionshipPositionModel>()));

            var response = await _championshipsController.CreateChampionship(Arg.Any<List<MovieModel>>()).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)response.Result).StatusCode);
            });
        }
    }
}
