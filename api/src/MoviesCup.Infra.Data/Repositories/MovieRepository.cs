using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesCup.Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly HttpClient _client;

        public MovieRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            const string moviesUrl = "http://copafilmes.azurewebsites.net/api/filmes";

            var response = await _client.GetAsync(new Uri(moviesUrl)).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default(IEnumerable<Movie>);

           var listMovieDtos = JsonConvert.DeserializeObject<List<MovieDto>>(
               await response.Content.ReadAsStringAsync().ConfigureAwait(false) ?? string.Empty);

            return listMovieDtos?.Select(m => new Movie(m.Id, m.Title, m.Year, m.Rate));
        }
    }
}
