namespace MoviesCup.Domain
{
    public class Movie
    {
        public Movie(string id, string title, int year, decimal rate)
        {
            Id = id;
            Title = title;
            Year = year;
            Rate = rate;
        }

        public string Id { get; }
        public string Title { get; }
        public int Year { get; }
        public decimal Rate { get; }
    }
}
