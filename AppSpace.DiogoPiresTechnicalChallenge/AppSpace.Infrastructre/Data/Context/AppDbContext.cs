using AppSpace.Domain.Cinema.Entities;
using AppSpace.Domain.Genre.Aggregates;
using AppSpace.Domain.Genre.Entities;
using AppSpace.Domain.Movie.Entities;
using AppSpace.Domain.Room.Entities;
using AppSpace.Domain.Sessions.Entities;
using AppSpace.Infrastructure.Data.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>(new MovieGenreMapping().Configure); 
        }

        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Movie> Movie { get; set; }
    }
}
