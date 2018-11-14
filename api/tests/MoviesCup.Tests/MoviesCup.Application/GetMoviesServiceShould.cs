using MoviesCup.Application;
using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Domain;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCup.Tests.MoviesCup.Application
{
    public class GetMoviesServiceShould
    {
        private IMovieRepository _movieRepository;
        private GetMoviesService _getMoviesService;

        [SetUp]
        public void SetUp()
        {
            _movieRepository = Substitute.For<IMovieRepository>();
            _getMoviesService = new GetMoviesService(_movieRepository);
        }

        [Test]
        public async Task ReturnNullWhenRepositoryReturnsNull()
        {
            _movieRepository
                .GetAll()
                .ReturnsNull();

            var response = await _getMoviesService.GetMovies().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNull(response);
                _movieRepository.Received(1).GetAll();
            });
        }

        [Test]
        public async Task ReturnMoviesWhenRepositoryReturnsMovies()
        {
            var expectedMovie = new Movie("t1", "Filme 1", 2017, 7.9M);

            var movies = new List<Movie>
            {
                expectedMovie
            };

            _movieRepository
                .GetAll()
                .Returns(movies);

            var response = (await _getMoviesService.GetMovies().ConfigureAwait(false)).ToList();
            var responseMovie = response.FirstOrDefault();

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.IsNotNull(responseMovie);
                Assert.AreEqual(movies.Count, response.Count);
                Assert.AreEqual(expectedMovie.Id, responseMovie.Id);
                Assert.AreEqual(expectedMovie.Title, responseMovie.Title);
                Assert.AreEqual(expectedMovie.Year, responseMovie.Year);

                _movieRepository.Received(1).GetAll();
            });
        }
    }
}
