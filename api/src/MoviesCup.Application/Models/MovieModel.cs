namespace MoviesCup.Application.Models
{
    public class MovieModel
    {
        public MovieModel(string id, string title)
        {
            Id = id;
            Title = title;
        }

        public string Id { get; }
        public string Title { get; }
    }
}
