using System.Collections.Generic;

namespace MoviesCup.Application.Models
{
    public class ChampionshipModel
    {
        public ChampionshipModel(IEnumerable<ChampionshipPositionModel> classification)
        {
            Classification = classification;
        }

        public IEnumerable<ChampionshipPositionModel> Classification { get; set; }
    }
}
