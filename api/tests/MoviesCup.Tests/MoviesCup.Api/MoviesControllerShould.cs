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
            const string expectedError = "Não foi possível localizar os filmes.";

            _getMoviesService
                .GetMovies()
                .ReturnsNull();

            var response = await _moviesController.Get().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                var actionResult = ((BadRequestObjectResult) response.Result);
                Assert.AreEqual((int)HttpStatusCode.BadRequest, actionResult.StatusCode);
                Assert.AreEqual(expectedError, actionResult.Value.ToString());
            });
        }

        [Test]
        public async Task ReturnOkWhenGetMoviesReturns()
        {
            _getMoviesService
                .GetMovies()
                .Returns(Enumerable.Empty<MovieModel>());

            var response = await _moviesController.Get().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.AreEqual((int)HttpStatusCode.OK, ((ObjectResult)response.Result).StatusCode);
            });
        }
    }
}
