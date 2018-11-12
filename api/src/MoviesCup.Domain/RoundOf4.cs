using System.Collections.Generic;
using System.Linq;

namespace MoviesCup.Domain
{
    public class RoundOf4 : RoundBase
    {
        public override bool MatchRound(List<Movie> movies) => movies.Count == 4;

        public override List<Match> ResolveRound(List<Movie> movies)
        {
            var matches = new List<Match>();

            if (!MatchRound(movies))
                return matches;

            var middleIndex = movies.Count / 2;
            var bracketOne = movies.Take(middleIndex).ToList();
            var bracketTwo = movies.Skip(middleIndex).ToList();

            matches.Add(DecideWinner(bracketOne.First(), bracketOne.Last()));
            matches.Add(DecideWinner(bracketTwo.First(), bracketTwo.Last()));

            return matches;
        }
    }
}
