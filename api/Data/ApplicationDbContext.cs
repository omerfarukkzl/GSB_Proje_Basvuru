using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Tipler> Tipler { get; set; }
        public DbSet<Basvuru> Basvuru { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tbl_Ref tablosu için yapılandırmalar
            modelBuilder.Entity<Tipler>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("INT");

            modelBuilder.Entity<Tipler>()
                .Property(t => t.Tip)
                .HasColumnType("VARCHAR(50)");

            modelBuilder.Entity<Tipler>()
                .Property(t => t.AltTip)
                .HasColumnType("VARCHAR(50)");

            modelBuilder.Entity<Tipler>()
                .Property(t => t.SilinmeDurumu);

            

      /*      // Basvuru tablosu için yapılandırmalar
            modelBuilder.Entity<Basvuru>()
                .HasKey(b => b.BasvuruId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.BasvuranBirim)
                .WithMany()
                .HasForeignKey(b => b.BasvuranBirimId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.BasvuruYapilanProje)
                .WithMany()
                .HasForeignKey(b => b.BasvuruYapilanProjeId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.BasvuruYapilanTur)
                .WithMany()
                .HasForeignKey(b => b.BasvuruYapilanTurId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.KatilimciTuru)
                .WithMany()
                .HasForeignKey(b => b.KatilimciTuruId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.BasvuruDonemi)
                .WithMany()
                .HasForeignKey(b => b.BasvuruDonemiId);

            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.BasvuruDurumu)
                .WithMany()
                .HasForeignKey(b => b.BasvuruDurumuId);

            // Kullanici tablosu için yapılandırmalar
            modelBuilder.Entity<Kullanici>()
                .HasKey(k => k.KullaniciId);

            // BasvuruKullanici tablosu için yapılandırmalar
            modelBuilder.Entity<BasvuruKullanici>()
                .HasKey(bk => bk.BasvuruKullaniciId);

            modelBuilder.Entity<BasvuruKullanici>()
                .HasOne(bk => bk.Basvuru)
                .WithMany()
                .HasForeignKey(bk => bk.BasvuruId);

            modelBuilder.Entity<BasvuruKullanici>()
                .HasOne(bk => bk.Kullanici)
                .WithMany()
                .HasForeignKey(bk => bk.KullaniciId);

            // Tüm string property'ler için global bir mapping
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetColumnType("varchar(255)"); // ya da "text"
                    }
                }
            }*/
        }
    }
}