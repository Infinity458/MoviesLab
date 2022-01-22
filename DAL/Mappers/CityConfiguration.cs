using System;
using System.Collections.Generic;
using Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(100);

            builder.HasOne(a => a.Country)
                .WithMany(c => c.Cities)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
