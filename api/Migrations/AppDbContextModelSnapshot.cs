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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Bilgi İşlem",
                            TipId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ad = "İnsan Kaynakları",
                            TipId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ad = "Yatırım İşleri",
                            TipId = 1
                        },
                        new
                        {
                            Id = 4,
                            Ad = "Erasmus",
                            TipId = 2
                        },
                        new
                        {
                            Id = 5,
                            Ad = "Merkezi",
                            TipId = 2
                        },
                        new
                        {
                            Id = 6,
                            Ad = "Avrupa",
                            TipId = 2
                        },
                        new
                        {
                            Id = 7,
                            Ad = "Diğer",
                            TipId = 2
                        },
                        new
                        {
                            Id = 8,
                            Ad = "Gençlik",
                            TipId = 3
                        },
                        new
                        {
                            Id = 9,
                            Ad = "Yetişkin",
                            TipId = 3
                        },
                        new
                        {
                            Id = 10,
                            Ad = "Spor",
                            TipId = 3
                        },
                        new
                        {
                            Id = 11,
                            Ad = "Mesleki",
                            TipId = 3
                        },
                        new
                        {
                            Id = 12,
                            Ad = "Dijital",
                            TipId = 3
                        },
                        new
                        {
                            Id = 13,
                            Ad = "Diğer",
                            TipId = 3
                        },
                        new
                        {
                            Id = 14,
                            Ad = "Koordinatör",
                            TipId = 4
                        },
                        new
                        {
                            Id = 15,
                            Ad = "Ortak",
                            TipId = 4
                        },
                        new
                        {
                            Id = 16,
                            Ad = "R1",
                            TipId = 5
                        },
                        new
                        {
                            Id = 17,
                            Ad = "R2",
                            TipId = 5
                        },
                        new
                        {
                            Id = 18,
                            Ad = "R3",
                            TipId = 5
                        },
                        new
                        {
                            Id = 19,
                            Ad = "Kabul",
                            TipId = 6
                        },
                        new
                        {
                            Id = 20,
                            Ad = "Red",
                            TipId = 6
                        });
                });

            modelBuilder.Entity("Basvuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AciklanmaTarihi")
                        .HasColumnType("timestamp");

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

                    b.Property<int?>("KullaniciId")
                        .HasColumnType("integer");

                    b.Property<string>("ProjeAdi")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("SilinmeDurumu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("BasvuranBirimId");

                    b.HasIndex("BasvuruDonemId");

                    b.HasIndex("BasvuruDurumId");

                    b.HasIndex("BasvuruYapilanProjeId");

                    b.HasIndex("BasvuruYapilanTurId");

                    b.HasIndex("KatilimciTurId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Basvuru", (string)null);
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AktiflikDurumu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("SilinmeDurumu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanici", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AktiflikDurumu = true,
                            KullaniciAdi = "admin",
                            RolId = 1,
                            Sifre = "admin",
                            SilinmeDurumu = false
                        },
                        new
                        {
                            Id = 2,
                            AktiflikDurumu = true,
                            KullaniciAdi = "user",
                            RolId = 2,
                            Sifre = "user",
                            SilinmeDurumu = false
                        });
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

            modelBuilder.Entity("api.Entities.Roller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RolAdi")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roller", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RolAdi = "admin"
                        },
                        new
                        {
                            Id = 2,
                            RolAdi = "user"
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
                    b.HasOne("AltTip", "BasvuranBirim")
                        .WithMany("ListBasvuranBirim")
                        .HasForeignKey("BasvuranBirimId")
                        .HasConstraintName("FK_Basvuru_BasvuranBirimId");

                    b.HasOne("AltTip", "BasvuruDonemi")
                        .WithMany("ListBasvuruDonemi")
                        .HasForeignKey("BasvuruDonemId")
                        .HasConstraintName("FK_Basvuru_BasvuruDonemId");

                    b.HasOne("AltTip", "BasvuruDurumu")
                        .WithMany("ListBasvuruDurumu")
                        .HasForeignKey("BasvuruDurumId")
                        .HasConstraintName("FK_Basvuru_BasvuruDurumId");

                    b.HasOne("AltTip", "BasvuruYapilanProje")
                        .WithMany("ListBasvuruYapilanProje")
                        .HasForeignKey("BasvuruYapilanProjeId")
                        .HasConstraintName("FK_Basvuru_BasvuruYapilanProjeId");

                    b.HasOne("AltTip", "BasvuruYapilanTur")
                        .WithMany("ListBasvuruYapilanTur")
                        .HasForeignKey("BasvuruYapilanTurId")
                        .HasConstraintName("FK_Basvuru_BasvuruYapilanTurId");

                    b.HasOne("AltTip", "KatilimciTuru")
                        .WithMany("ListKatilimciTuru")
                        .HasForeignKey("KatilimciTurId")
                        .HasConstraintName("FK_Basvuru_KatilimciTurId");

                    b.HasOne("Kullanici", "BasvuranKullanici")
                        .WithMany("ListBasvuranKullanici")
                        .HasForeignKey("KullaniciId")
                        .HasConstraintName("FK_Basvuru_KullaniciId");

                    b.Navigation("BasvuranBirim");

                    b.Navigation("BasvuranKullanici");

                    b.Navigation("BasvuruDonemi");

                    b.Navigation("BasvuruDurumu");

                    b.Navigation("BasvuruYapilanProje");

                    b.Navigation("BasvuruYapilanTur");

                    b.Navigation("KatilimciTuru");
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.HasOne("api.Entities.Roller", "KullaniciRol")
                        .WithMany("ListRoller")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK_Kullanici_RolId");

                    b.Navigation("KullaniciRol");
                });

            modelBuilder.Entity("AltTip", b =>
                {
                    b.Navigation("ListBasvuranBirim");

                    b.Navigation("ListBasvuruDonemi");

                    b.Navigation("ListBasvuruDurumu");

                    b.Navigation("ListBasvuruYapilanProje");

                    b.Navigation("ListBasvuruYapilanTur");

                    b.Navigation("ListKatilimciTuru");
                });

            modelBuilder.Entity("Kullanici", b =>
                {
                    b.Navigation("ListBasvuranKullanici");
                });

            modelBuilder.Entity("Tip", b =>
                {
                    b.Navigation("ListAltTipler");
                });

            modelBuilder.Entity("api.Entities.Roller", b =>
                {
                    b.Navigation("ListRoller");
                });
#pragma warning restore 612, 618
        }
    }
}
