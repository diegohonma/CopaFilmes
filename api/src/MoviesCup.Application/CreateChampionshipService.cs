using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Application.Models;
using MoviesCup.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCup.Application
{
    public class CreateChampionshipService : ICreateChampionshipService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICreateClassificationService _createClassificationService;

        public CreateChampionshipService(
            IMovieRepository movieRepository,
            ICreateClassificationService createClassificationService)
        {
            _movieRepository = movieRepository;
            _createClassificationService = createClassificationService;
        }

        public async Task<ChampionshipModel> CreateChampionship(List<MovieModel> moviesModel)
        {
            if (moviesModel == null)
                return default(ChampionshipModel);

            var idsChampionshipMovies = moviesModel.Select(m => m.Id).ToArray();
            var movies = await _movieRepository.GetAll().ConfigureAwait(false);
            movies = movies?
                .Where(m => idsChampionshipMovies.Contains(m.Id))
                .Select(m => new Movie(m.Id, m.Title, m.Year, m.Rate));

            return movies == null
                ? null
                : new ChampionshipModel(
                    _createClassificationService
                        .CreateClassification(movies.ToList())?.Select(
                            m => new ChampionshipPositionModel(m.Position, new MovieModel(m.Movie.Id, m.Movie.Title, m.Movie.Year))));
        }
    }
}
