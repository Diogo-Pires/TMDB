using AppSpace.Infrastructure.Data.Context;
using AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Interfaces;
using AppSpace.Infrastructure.Data.WebServices.TheMovieDb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppSpace.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: This one below should go to a configuration file and be grabbed using a singleton
            services.AddHttpClient("TMDB", x=> x.BaseAddress = new Uri("https://api.themoviedb.org/3/discover/movie?"));

            // Add services to the container.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MediaDb"));
            });

            services.AddScoped<ITMDBService, TMDBService>();

            return services;
        }
    };
}