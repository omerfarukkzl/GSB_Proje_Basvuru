using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Mappings
{
    public class KullaniciMap : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.KullaniciAdi).HasColumnType("varchar(50)");
            builder.Property(a => a.Sifre).HasColumnType("varchar(50)");
            builder.Property(a => a.RolId).HasColumnType("int").HasDefaultValue(2);
            builder.Property(a => a.SilinmeDurumu);

            builder.HasOne<Roller>(a => a.KullaniciRol).WithMany(a => a.ListRoller).HasForeignKey(a => a.RolId).HasConstraintName("FK_Kullanici_RolId");



           // builder.HasOne<IYS_tblUlkeler>(a => a.KEY_ulke_ID_FK).WithMany(a => a.LIST_IYS_tblIlceler_ulke_ID_FK).HasForeignKey(a => a.ulke_ID_FK).HasConstraintName("FK_IYSIlce_ulke_ID");
            builder.ToTable(nameof(Kullanici));

            builder.HasData(
                new Kullanici { Id=1, KullaniciAdi = "admin", Sifre = "admin", RolId = 1 },
                new Kullanici { Id=2, KullaniciAdi = "user", Sifre = "user", RolId = 2 }
                );

            
        }
    }
}