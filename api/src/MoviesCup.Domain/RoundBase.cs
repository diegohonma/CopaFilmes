using System;
using System.Collections.Generic;

namespace MoviesCup.Domain
{
    public abstract class RoundBase
    {
        public abstract bool MatchRound(List<Movie> movies);

        public abstract List<Match> ResolveRound(List<Movie> movies);

        protected static Match DecideWinner(Movie movieOne, Movie movieTwo)
        {
            var match = new Match();
            var isMovieOneTheWinner = movieOne.Rate > movieTwo.Rate ||
                                      (movieOne.Rate == movieTwo.Rate 
                                       && string.Compare(movieOne.Title, movieTwo.Title, StringComparison.CurrentCultureIgnoreCase) == -1);

            match.Winner = isMovieOneTheWinner ? movieOne : movieTwo;
            match.Loser = isMovieOneTheWinner ? movieTwo : movieOne;

            return match;
        }
    }
}
