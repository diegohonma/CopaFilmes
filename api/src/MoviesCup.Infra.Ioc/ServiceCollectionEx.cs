using Microsoft.Extensions.DependencyInjection;
using MoviesCup.Application;
using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Interfaces.Repositories;
using MoviesCup.Domain;
using MoviesCup.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Net.Http;

namespace MoviesCup.Infra.Ioc
{
    public static class ServiceCollectionEx
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();

            RegisterRepositories(services);
            RegisterApplicationServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddTransient<IGetMoviesService, GetMoviesService>();
            services.AddTransient<ICreateChampionshipService, CreateChampionshipService>();
            services.AddTransient<ICreateClassificationService, CreateClassificationService>();

            services.AddSingleton(new List<RoundBase>()
            {
                new RoundOf8(),
                new RoundOf4(),
                new RoundOf2()
            });
        }
    }
}
