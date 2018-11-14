namespace MoviesCup.Application.Models
{
    public class MovieModel
    {
        public MovieModel(string id, string title, int year)
        {
            Id = id;
            Title = title;
            Year = year;
        }

        public string Id { get; }
        public string Title { get; }
        public int Year { get; }
    }
}
