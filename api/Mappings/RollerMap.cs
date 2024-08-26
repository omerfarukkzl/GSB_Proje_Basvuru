using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Mappings
{
    public class RollerMap : IEntityTypeConfiguration<Roller>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Roller> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.RolAdi).HasColumnType("varchar(50)");
            builder.ToTable(nameof(Roller));

            builder.HasData(
                new Roller { Id=1, RolAdi = "admin" },
                new Roller { Id=2, RolAdi = "user" }
                );





        }
    }
}