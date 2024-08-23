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
            
        }
    }
}