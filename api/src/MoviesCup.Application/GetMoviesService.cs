using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCup.Application
{
    public class GetMoviesService : IGetMoviesService
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieModel>> GetMovies() =>
            (await _movieRepository.GetAll().ConfigureAwait(false))?.Select(m => new MovieModel(m.Id, m.Title));
    }
}
