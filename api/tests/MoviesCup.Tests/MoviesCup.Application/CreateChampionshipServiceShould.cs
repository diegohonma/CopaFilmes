using MoviesCup.Application;
using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Application.Models;
using MoviesCup.Domain;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCup.Tests.MoviesCup.Application
{
    internal class CreateChampionshipServiceShould
    {
        private IMovieRepository _movieRepository;
        private ICreateClassificationService _createClassificationService;
        private CreateChampionshipService _createChampionshipService;

        [SetUp]
        public void SetUp()
        {
            _movieRepository = Substitute.For<IMovieRepository>();
            _createClassificationService = Substitute.For<ICreateClassificationService>();
            _createChampionshipService = new CreateChampionshipService(_movieRepository, _createClassificationService);
        }

        [Test]
        public async Task ReturnNullWhenMoviesNotFound()
        {
            _movieRepository
                .GetAll()
                .ReturnsNull();

            var response = await 
                _createChampionshipService.CreateChampionship(new List<MovieModel>()
                {
                    new MovieModel("t1", "T")
                }).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNull(response);
                _movieRepository.Received(1).GetAll();
            });
        }

        [Test]
        public async Task ReturnNullWheNoMoviesSent()
            => Assert.IsNull(await _createChampionshipService.CreateChampionship(null).ConfigureAwait(false));

        [Test]
        public async Task ReturnChampionship()
        {
            var movies = new List<Movie>
            {
                new Movie("t1", "Filme 1", 2018, 8.2M),
                new Movie("t2", "Filme 2", 2018, 7.9M)
            };

            _movieRepository
                .GetAll()
                .Returns(movies);

            _createClassificationService
                .CreateClassification(Arg.Any<List<Movie>>())
                .Returns(new List<ChampionshipPosition>
                {
                    new ChampionshipPosition(1, movies.First())
                });

            var response = await _createChampionshipService.CreateChampionship(new List<MovieModel>()).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.IsNotEmpty(response.Classification);
                Assert.AreEqual(1, response.Classification.Count());

                _movieRepository.Received(1).GetAll();
                _createClassificationService.Received(1).CreateClassification(Arg.Any<List<Movie>>());
            });
        }
    }
}
