using Newtonsoft.Json;

namespace MoviesCup.Infra.Data
{
    internal class MovieDto
    {
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Title { get; set; }

        [JsonProperty("ano")]
        public int Year { get; set; }

        [JsonProperty("nota")]
        public decimal Rate { get; set; }
    }
}
