namespace MoviesCup.Domain
{
    public class ChampionshipPosition
    {
        public ChampionshipPosition(int position, Movie movie)
        {
            Position = position;
            Movie = movie;
        }

        public int Position { get; }
        public Movie Movie { get; }
    }
}
