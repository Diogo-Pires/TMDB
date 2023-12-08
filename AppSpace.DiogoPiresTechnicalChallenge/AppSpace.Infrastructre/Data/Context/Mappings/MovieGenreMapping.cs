using AppSpace.Domain.Genre.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSpace.Infrastructure.Data.Context.Mappings
{
    public class MovieGenreMapping : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasNoKey();
        }
    }
}
