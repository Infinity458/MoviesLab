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
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Birth).HasMaxLength(15);

            builder.HasOne(a => a.Gender)
                .WithMany(c => c.Actors)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.City)
                .WithMany(c => c.Actors)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.Movies)
                .WithMany(b => b.Actors)
                .UsingEntity(t => t.ToTable("MovieActors"));
        }
    }
}
