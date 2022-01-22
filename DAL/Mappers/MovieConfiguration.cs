using Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Budget).HasMaxLength(100);

            builder.HasOne(a => a.ProductionCompany)
                .WithMany(c => c.Movies)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Director)
                .WithMany(c => c.Movies)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.Genre)
                .WithMany(c => c.Movies)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
