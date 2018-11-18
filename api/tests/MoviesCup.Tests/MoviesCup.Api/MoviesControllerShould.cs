using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesCup.Api.Controllers;
using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Models;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoviesCup.Tests.MoviesCup.Api
{
    internal class MoviesControllerShould
    {
        private IGetMoviesService _getMoviesService;
        private MoviesController _moviesController;

        [SetUp]
        public void SetUp()
        {
            _getMoviesService = Substitute.For<IGetMoviesService>();
            _moviesController = new MoviesController(_getMoviesService);
        }

        [Test]
        public async Task ReturnBadRequestWhenGetMoviesReturnsNull()
        {
            _getMoviesService
                .GetMovies()
                .ReturnsNull();

            var response = await _moviesController.Get().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                var actionResult = ((NoContentResult) response.Result);
                Assert.AreEqual((int)HttpStatusCode.NoContent, actionResult.StatusCode);
            });
        }

        [Test]
        public async Task ReturnOkWhenGetMoviesReturns()
        {
            _getMoviesService
                .GetMovies()
                .Returns(new List<MovieModel>()
                {
                    new MovieModel("f1", "Filme 1", 2018)
                });

            var response = await _moviesController.Get().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)response.Result).StatusCode);
            });
        }
    }
}
