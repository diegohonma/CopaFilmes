namespace MoviesCup.Application.Models
{
    public class ChampionshipPositionModel
    {
        public ChampionshipPositionModel(int position, MovieModel movieModel)
        {
            Position = position;
            Movie = movieModel;
        }

        public int Position { get; }
        public MovieModel Movie { get; }
    }
}
