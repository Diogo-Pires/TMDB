using AppSpace.Application.Movies.Interfaces;
using AppSpace.Application.Movies.Services;
using AppSpace.Domain.Documentaries.Repositories;
using AppSpace.Domain.Genre.Repositories;
using AppSpace.Domain.Movie.Repositories;
using AppSpace.Domain.TMDBMovie.Repositories;
using AppSpace.Domain.TvShows.Repositories;
using AppSpace.Infrastructure.Data.Context;
using AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AppSpace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IDocumentaryRepository, DocumentaryRepository>();
            services.AddScoped<ITvShowRepository, TvShowRepository>();
            services.AddScoped<ITMDBMovieRepository, TMDBMovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            var host = services.BuildServiceProvider();

            services.AddScoped<IList<IMovieSourceForIntelligentBillboardService>>(x => new List<IMovieSourceForIntelligentBillboardService>()
            {
                { new DBMovieSourceForIntelligentBillboardService(host.GetRequiredService<IMovieRepository>()) },
                { new TMDBMovieSourceForIntelligentBillboardService(host.GetRequiredService<ITMDBMovieRepository>()) }
            });

            return services;
        }
    };
}
