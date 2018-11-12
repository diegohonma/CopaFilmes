using MoviesCup.Infra.Data.Repositories;
using MoviesCup.Tests.Helpers;
using NSubstitute;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesCup.Tests.MoviesCup.Infra.Data
{
    internal class MovieRepositoryShould
    {
        [Test]
        public async Task ReturnNullWhenNotSuccessStatusCode()
        {
            var httpClient = Substitute.For<HttpClient>(new FakeDelegatingHandler(HttpStatusCode.InternalServerError, "teste"));
            var movieRepository = new MovieRepository(httpClient);
            var response = await movieRepository.GetAll().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNull(response);
                httpClient.ReceivedWithAnyArgs(1).GetAsync("http://localhost");
            });
        }

        [Test]
        public async Task ReturnMoviesWhenMoviesFound()
        {
            const string expectedResponse = @"[
            {
                'id': 'tt3606756',
                'titulo': 'Os Incríveis 2',
                'ano': 2018,
                'nota': 8.5
            },
            {
                'id': 'tt4881806',
                'titulo': 'Jurassic World: Reino Ameaçado',
                'ano': 2018,
                'nota': 6.7
            }]";

            var httpClient = Substitute.For<HttpClient>(new FakeDelegatingHandler(HttpStatusCode.OK, expectedResponse));
            var movieRepository = new MovieRepository(httpClient);
            var response = await movieRepository.GetAll().ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response);
                Assert.IsNotEmpty(response);
                httpClient.ReceivedWithAnyArgs(1).GetAsync("http://localhost");
            });
        }
    }
}
