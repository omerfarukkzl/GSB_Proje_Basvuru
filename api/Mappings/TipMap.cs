using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Mappings
{
    public class TipMap : IEntityTypeConfiguration<Tip>
    {
        public void Configure(EntityTypeBuilder<Tip> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Ad).HasColumnType("varchar(50)");

            builder.ToTable(nameof(Tip));

            builder.HasData(
                new Tip { Id=1, Ad = "Başvuran Birim" },
                new Tip { Id=2, Ad = "Basvuru Yapılan Proje" },
                new Tip { Id=3, Ad = "Başvuru Yapılan Tür" },
                new Tip { Id=4, Ad = "Katılımcı Türü" },
                new Tip { Id=5, Ad = "Başvuru Dönemi" },
                new Tip { Id=6, Ad = "Başvuru Durumu" }          
                );

        }
    }
}