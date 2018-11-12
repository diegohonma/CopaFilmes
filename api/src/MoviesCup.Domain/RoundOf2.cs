using System.Collections.Generic;
using System.Linq;

namespace MoviesCup.Domain
{
    public class RoundOf2 : RoundBase
    {
        public override bool MatchRound(List<Movie> movies) => movies.Count == 2;

        public override List<Match> ResolveRound(List<Movie> movies)
        {
            var matches = new List<Match>();

            if (!MatchRound(movies))
                return matches;

            matches.Add(DecideWinner(movies.First(), movies.Last()));

            return matches;
        }
    }
}
