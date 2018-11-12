using MoviesCup.Application;
using MoviesCup.Domain;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCup.Tests.MoviesCup.Application
{
    internal class CreateClassificationServiceShould
    {
        private CreateClassificationService _createClassificationService;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _createClassificationService = new CreateClassificationService(new List<RoundBase>()
            {
                new RoundOf8(), new RoundOf4(), new RoundOf2()
            });
        }

        [Test]
        public void ReturnCorrectClassificationForEightMovies()
        {
            var response = _createClassificationService.CreateClassification(new List<Movie>()
            {
                new Movie("tt3606756", "Os Incríveis 2", 2018, 8.5M),
                new Movie("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7M),
                new Movie("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3M),
                new Movie("tt7784604", "Hereditário", 2018, 7.8M),
                new Movie("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8M),
                new Movie("tt5463162", "Deadpool 2", 2018, 8.1M),
                new Movie("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2M),
                new Movie("tt3501632", "Thor: Ragnarok", 2018, 7.9M)
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, response.Count);
                Assert.AreEqual("Vingadores: Guerra Infinita", response.FirstOrDefault(x => x.Position == 1)?.Movie.Title);
                Assert.AreEqual("Os Incríveis 2", response.FirstOrDefault(x => x.Position == 2)?.Movie.Title);
            });
        }

        [TestCase("Filme A", "Filme B", ExpectedResult = true)]
        [TestCase("Filme C", "Filme B", ExpectedResult = false)]
        public bool ReturnCorrectClassificationWhenSameRate(string firstMovie, string secondMovie)
        {
            var response = _createClassificationService.CreateClassification(new List<Movie>()
            {
                new Movie("tt3606756", firstMovie, 2018, 8.5M),
                new Movie("tt3606756", secondMovie, 2018, 8.5M),
            });

            return firstMovie.Equals(response.FirstOrDefault(x => x.Position == 1)?.Movie.Title);
        }

        [Test]
        public void ReturnNullWhenNoRoundFound()
        {
            var response = _createClassificationService.CreateClassification(new List<Movie>());
            Assert.IsNull(response);
        }
    }
}
