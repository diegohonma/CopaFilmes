using MoviesCup.Domain;
using System.Collections.Generic;

namespace MoviesCup.Application.Interfaces
{
    public interface ICreateClassificationService
    {
        List<ChampionshipPosition> CreateClassification(List<Movie> movies);
    }
}
