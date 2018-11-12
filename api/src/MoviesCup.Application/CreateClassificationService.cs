using MoviesCup.Application.Interfaces;
using MoviesCup.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MoviesCup.Application
{
    public class CreateClassificationService : ICreateClassificationService
    {
        private readonly List<RoundBase> _rounds;

        public CreateClassificationService(List<RoundBase> rounds)
        {
            _rounds = rounds;
        }

        public List<ChampionshipPosition> CreateClassification(List<Movie> movies)
        {
            var classification = new List<ChampionshipPosition>();

            var round = _rounds.FirstOrDefault(r => r.MatchRound(movies));

            if (round == null)
                return null;

            var matches = round.ResolveRound(movies);
            var winners = matches.Select(m => m.Winner).ToList();

            if (winners.Count > 1)
                return CreateClassification(winners);

            winners.ForEach(winner =>
                classification.Add(
                    new ChampionshipPosition(classification.Count + 1, winner)));

            matches.Select(m => m.Loser).ToList().ForEach(loser =>
                classification.Add(
                    new ChampionshipPosition(classification.Count + 1, loser)));

            return classification;
        }
    }
}
