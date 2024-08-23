﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AltTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.Property<int>("TipId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TipId");

                    b.ToTable("AltTipler");
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AltTipId")
                        .HasColumnType("integer");

                    b.Property<string>("BasvuruAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BasvuruDurumId")
                        .HasColumnType("integer");

                    b.Property<int>("BasvuruYapilanProjeId")
                        .HasColumnType("integer");

                    b.Property<int>("BasvuruYapilanTurId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AltTipId");

                    b.HasIndex("BasvuruDurumId");

                    b.HasIndex("BasvuruYapilanProjeId");

                    b.HasIndex("BasvuruYapilanTurId");

                    b.ToTable("Basvurular");
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("KullaniciBasvuru", b =>
                {
                    b.Property<int>("KullaniciId")
                        .HasColumnType("integer");

                    b.Property<int>("BasvuruId")
                        .HasColumnType("integer");

                    b.HasKey("KullaniciId", "BasvuruId");

                    b.HasIndex("BasvuruId");

                    b.ToTable("KullaniciBasvurular");
                });

            modelBuilder.Entity("Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tipler");
                });

            modelBuilder.Entity("AltTip", b =>
                {
                    b.HasOne("Tip", "Tip")
                        .WithMany("AltTipler")
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.HasOne("AltTip", null)
                        .WithMany("Basvurular")
                        .HasForeignKey("AltTipId");

                    b.HasOne("Tip", "BasvuruDurumu")
                        .WithMany("Basvurular")
                        .HasForeignKey("BasvuruDurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tip", "BasvuruYapilanProje")
                        .WithMany("BasvurularProje")
                        .HasForeignKey("BasvuruYapilanProjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tip", "BasvuruYapilanTur")
                        .WithMany("BasvurularTur")
                        .HasForeignKey("BasvuruYapilanTurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasvuruDurumu");

                    b.Navigation("BasvuruYapilanProje");

                    b.Navigation("BasvuruYapilanTur");
                });

            modelBuilder.Entity("KullaniciBasvuru", b =>
                {
                    b.HasOne("Basvuru", "Basvuru")
                        .WithMany("KullaniciBasvurular")
                        .HasForeignKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kullanici", "Kullanici")
                        .WithMany("KullaniciBasvurulari")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basvuru");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("AltTip", b =>
                {
                    b.Navigation("Basvurular");
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.Navigation("KullaniciBasvurular");
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Navigation("KullaniciBasvurulari");
                });

            modelBuilder.Entity("Tip", b =>
                {
                    b.Navigation("AltTipler");

                    b.Navigation("Basvurular");

                    b.Navigation("BasvurularProje");

                    b.Navigation("BasvurularTur");
                });
#pragma warning restore 612, 618
        }
    }
}
