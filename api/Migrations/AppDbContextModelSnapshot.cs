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
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("SilinmeDurumu")
                        .HasColumnType("boolean");

                    b.Property<int?>("TipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipId");

                    b.ToTable("AltTip", (string)null);
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AciklanmaTarihi")
                        .HasColumnType("timestamp");

                    b.Property<int?>("AltTipId")
                        .HasColumnType("integer");

                    b.Property<int?>("BasvuranBirimId")
                        .HasColumnType("int");

                    b.Property<int?>("BasvuruDonemId")
                        .HasColumnType("int");

                    b.Property<int?>("BasvuruDurumId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BasvuruTarihi")
                        .HasColumnType("timestamp");

                    b.Property<int?>("BasvuruYapilanProjeId")
                        .HasColumnType("int");

                    b.Property<int?>("BasvuruYapilanTurId")
                        .HasColumnType("int");

                    b.Property<decimal?>("HibeTutari")
                        .HasColumnType("decimal");

                    b.Property<int?>("KatilimciTurId")
                        .HasColumnType("int");

                    b.Property<string>("ProjeAdi")
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("SilinmeDurumu")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AltTipId");

                    b.HasIndex("BasvuranBirimId");

                    b.HasIndex("BasvuruDonemId");

                    b.HasIndex("BasvuruDurumId");

                    b.HasIndex("BasvuruYapilanProjeId");

                    b.HasIndex("BasvuruYapilanTurId");

                    b.HasIndex("KatilimciTurId");

                    b.ToTable("Basvuru", (string)null);
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("SilinmeDurumu")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Kullanici", (string)null);
                });

            modelBuilder.Entity("KullaniciBasvuru", b =>
                {
                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilinmeDurumu")
                        .HasColumnType("boolean");

                    b.HasKey("KullaniciId", "BasvuruId");

                    b.HasIndex("BasvuruId");

                    b.ToTable("KullaniciBasvuru", (string)null);
                });

            modelBuilder.Entity("Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("SilinmeDurumu")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Tip", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Başvuran Birim"
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Basvuru Yapılan Proje"
                        },
                        new
                        {
                            Id = 3,
                            Ad = "Başvuru Yapılan Tür"
                        },
                        new
                        {
                            Id = 4,
                            Ad = "Katılımcı Türü"
                        },
                        new
                        {
                            Id = 5,
                            Ad = "Başvuru Dönemi"
                        },
                        new
                        {
                            Id = 6,
                            Ad = "Başvuru Durumu"
                        });
                });

            modelBuilder.Entity("AltTip", b =>
                {
                    b.HasOne("Tip", "Tip")
                        .WithMany("ListAltTipler")
                        .HasForeignKey("TipId")
                        .HasConstraintName("FK_AltTip_TipId");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.HasOne("AltTip", null)
                        .WithMany("ListBasvurular")
                        .HasForeignKey("AltTipId");

                    b.HasOne("Tip", "BasvuranBirim")
                        .WithMany("ListBasvuranBirim")
                        .HasForeignKey("BasvuranBirimId");

                    b.HasOne("Tip", "BasvuruDonemi")
                        .WithMany("ListBasvuruDonemi")
                        .HasForeignKey("BasvuruDonemId")
                        .HasConstraintName("FK_Basvuru_BasvuruDonemId");

                    b.HasOne("Tip", "BasvuruDurumu")
                        .WithMany("ListBasvuruDurumu")
                        .HasForeignKey("BasvuruDurumId")
                        .HasConstraintName("FK_Basvuru_BasvuruDurumId");

                    b.HasOne("Tip", "BasvuruYapilanProje")
                        .WithMany("ListBasvuruYapilanProje")
                        .HasForeignKey("BasvuruYapilanProjeId")
                        .HasConstraintName("FK_Basvuru_BasvuruYapilanProjeId");

                    b.HasOne("Tip", "BasvuruYapilanTur")
                        .WithMany("ListBasvuruYapilanTur")
                        .HasForeignKey("BasvuruYapilanTurId")
                        .HasConstraintName("FK_Basvuru_BasvuruYapilanTurId");

                    b.HasOne("Tip", "KatilimciTuru")
                        .WithMany("ListKatilimciTuru")
                        .HasForeignKey("KatilimciTurId")
                        .HasConstraintName("FK_Basvuru_KatilimciTurId");

                    b.Navigation("BasvuranBirim");

                    b.Navigation("BasvuruDonemi");

                    b.Navigation("BasvuruDurumu");

                    b.Navigation("BasvuruYapilanProje");

                    b.Navigation("BasvuruYapilanTur");

                    b.Navigation("KatilimciTuru");
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
                    b.Navigation("ListBasvurular");
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
                    b.Navigation("ListAltTipler");

                    b.Navigation("ListBasvuranBirim");

                    b.Navigation("ListBasvuruDonemi");

                    b.Navigation("ListBasvuruDurumu");

                    b.Navigation("ListBasvuruYapilanProje");

                    b.Navigation("ListBasvuruYapilanTur");

                    b.Navigation("ListKatilimciTuru");
                });
#pragma warning restore 612, 618
        }
    }
}
