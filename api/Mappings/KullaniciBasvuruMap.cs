using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Mappings
{
    public class KullaniciBasvuruMap : IEntityTypeConfiguration<KullaniciBasvuru>
    {
        public void Configure(EntityTypeBuilder<KullaniciBasvuru> builder)
        {
            builder.HasKey(a => new { a.KullaniciId, a.BasvuruId });

            builder.Property(a => a.KullaniciId).HasColumnType("int");
            builder.Property(a => a.BasvuruId).HasColumnType("int");
            builder.Property(a => a.SilinmeDurumu);


            builder.HasOne(a => a.Kullanici).WithMany(k => k.KullaniciBasvurulari).HasForeignKey(a => a.KullaniciId);
            builder.HasOne(a => a.Basvuru).WithMany(b => b.KullaniciBasvurular).HasForeignKey(a => a.BasvuruId);

            builder.ToTable(nameof(KullaniciBasvuru));
        }
    }
}