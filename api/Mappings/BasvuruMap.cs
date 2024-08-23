using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Mappings
{
    public class BasvuruMap : IEntityTypeConfiguration<Basvuru>
    {
        public void Configure(EntityTypeBuilder<Basvuru> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.ProjeAdi).HasColumnType("varchar(50)");
            builder.Property(a => a.BasvuranBirimId).HasColumnType("int");
            builder.Property(a => a.BasvuruYapilanProjeId).HasColumnType("int");
            builder.Property(a => a.BasvuruYapilanTurId).HasColumnType("int");
            builder.Property(a => a.KatilimciTurId).HasColumnType("int");
            builder.Property(a => a.BasvuruDonemId).HasColumnType("int");
            builder.Property(a => a.BasvuruDurumId).HasColumnType("int");

            builder.Property(a => a.BasvuruTarihi).HasColumnType("timestamp");
            builder.Property(a => a.AciklanmaTarihi).HasColumnType("timestamp");
            builder.Property(a => a.HibeTutari).HasColumnType("decimal");

            //builder.HasOne(a => a.BasvuruDurumu).WithMany(t => t.ListBasvurularDurum).HasForeignKey(a => a.BasvuruDurumId);
            //builder.HasOne(a => a.BasvuruYapilanProje).WithMany(t => t.ListBasvurularProje).HasForeignKey(a => a.BasvuruYapilanProjeId);
            //builder.HasOne(a => a.BasvuruYapilanTur).WithMany(t => t.ListBasvurularTur).HasForeignKey(a => a.BasvuruYapilanTurId);
            //builder.HasOne(a => a.BasvuruDonem).WithMany(t => t.ListBasvurularDonem).HasForeignKey(a => a.BasvuruDonemId);
            //builder.HasOne(a => a.BasvuranBirim).WithMany(t => t.ListBasvurularBirim).HasForeignKey(a => a.BasvuranBirimId);
            //builder.HasOne(a => a.KatilimciTur).WithMany(t => t.ListBasvurularTur).HasForeignKey(a => a.KatilimciTurId);

            builder.HasOne<Tip>(a => a.BasvuruDurumu).WithMany(a => a.ListBasvuruDurumu).HasForeignKey(a => a.BasvuruDurumId).HasConstraintName("FK_Basvuru_BasvuruDurumId");
            builder.HasOne<Tip>(a => a.BasvuruDurumu).WithMany(a => a.ListBasvuruDurumu).HasForeignKey(a => a.BasvuruDurumId).HasConstraintName("FK_Basvuru_BasvuruDurumId");
            builder.HasOne<Tip>(a => a.BasvuruYapilanProje).WithMany(a => a.ListBasvuruYapilanProje).HasForeignKey(a => a.BasvuruYapilanProjeId).HasConstraintName("FK_Basvuru_BasvuruYapilanProjeId");
            builder.HasOne<Tip>(a => a.BasvuruYapilanTur).WithMany(a => a.ListBasvuruYapilanTur).HasForeignKey(a => a.BasvuruYapilanTurId).HasConstraintName("FK_Basvuru_BasvuruYapilanTurId");
            builder.HasOne<Tip>(a => a.KatilimciTuru).WithMany(a => a.ListKatilimciTuru).HasForeignKey(a => a.KatilimciTurId).HasConstraintName("FK_Basvuru_KatilimciTurId");
            builder.HasOne<Tip>(a => a.BasvuruDonemi).WithMany(a => a.ListBasvuruDonemi).HasForeignKey(a => a.BasvuruDonemId).HasConstraintName("FK_Basvuru_BasvuruDonemId");

            builder.ToTable(nameof(Basvuru));
            
            
        }
    }
}