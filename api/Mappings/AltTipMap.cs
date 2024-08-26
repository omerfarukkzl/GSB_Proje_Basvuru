using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Mappings
{
    public class AltTipMap : IEntityTypeConfiguration<AltTip>

    {
        public void Configure(EntityTypeBuilder<AltTip> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            

            builder.Property(a => a.Ad).HasColumnType("varchar(50)");
            builder.Property(a => a.TipId).HasColumnType("int");
            builder.Property(a => a.SilinmeDurumu);
            //builder.HasOne(a => a.Tip).WithMany(t => t.ListAltTipler).HasForeignKey(a => a.TipId);

            builder.HasOne<Tip>(a => a.Tip).WithMany(a => a.ListAltTipler).HasForeignKey(a => a.TipId).HasConstraintName("FK_AltTip_TipId");


            builder.ToTable(nameof(AltTip));

            builder.HasData(
                new AltTip { Id=1, TipId=1, Ad = "Bilgi İşlem" },
                new AltTip { Id=2, TipId=1, Ad = "İnsan Kaynakları" },
                new AltTip { Id=3, TipId=1, Ad = "Yatırım İşleri" },
                new AltTip { Id=4, TipId=2, Ad = "Erasmus" },
                new AltTip { Id=5, TipId=2, Ad = "Merkezi" },
                new AltTip { Id=6, TipId=2, Ad = "Avrupa" },
                new AltTip { Id=7, TipId=2, Ad = "Diğer" },
                new AltTip { Id=8, TipId=3, Ad = "Gençlik" },
                new AltTip { Id=9, TipId=3, Ad = "Yetişkin" },
                new AltTip { Id=10, TipId=3, Ad = "Spor" },
                new AltTip { Id=11, TipId=3, Ad = "Mesleki" },
                new AltTip { Id=12, TipId=3, Ad = "Dijital" },
                new AltTip { Id=13, TipId=3, Ad = "Diğer" },
                new AltTip { Id=14, TipId=4, Ad = "Koordinatör" },
                new AltTip { Id=15, TipId=4, Ad = "Ortak" },
                new AltTip { Id=16, TipId=5, Ad = "R1" },
                new AltTip { Id=17, TipId=5, Ad = "R2" },
                new AltTip { Id=18, TipId=5, Ad = "R3" },
                new AltTip { Id=19, TipId=6, Ad = "Kabul" },
                new AltTip { Id=20, TipId=6, Ad = "Red" }


                       
                );

            

            
            
        }
    }
}