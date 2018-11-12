using System.Collections.Generic;
using System.Linq;

namespace MoviesCup.Domain
{
    public class RoundOf8 : RoundBase
    {
        public override bool MatchRound(List<Movie> movies) => movies.Count == 8;

        public override List<Match> ResolveRound(List<Movie> movies)
        {
            var matches = new List<Match>();

            if (!MatchRound(movies))
                return matches;
            
            var middleIndex = movies.Count / 2;

            movies = movies.OrderBy(m => m.Title).ToList();
            var bracketOne = movies.Take(middleIndex).ToArray();
            var bracketTwo = movies.Skip(middleIndex).Reverse().ToArray();

            for (var i = 0; i < middleIndex; i++)
            {
                var match = DecideWinner(bracketOne[i], bracketTwo[i]);
                matches.Add(match);
            }

            return matches;
        }
    }
}
