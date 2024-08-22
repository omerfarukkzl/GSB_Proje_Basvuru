using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "varchar(255)", nullable: false),
                    Sifre = table.Column<string>(type: "varchar(255)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(255)", nullable: false),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "TblRefs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tip = table.Column<string>(type: "varchar(255)", nullable: false),
                    AltTip = table.Column<string>(type: "varchar(255)", nullable: false),
                    Silinme_Durumu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Basvurus",
                columns: table => new
                {
                    BasvuruId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeAdi = table.Column<string>(type: "varchar(255)", nullable: false),
                    BasvuranBirimId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BasvuruYapilanProjeId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BasvuruYapilanTurId = table.Column<string>(type: "varchar(50)", nullable: false),
                    KatilimciTuruId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BasvuruDonemiId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BasvuruDurumuId = table.Column<string>(type: "varchar(50)", nullable: false),
                    BasvuruTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AciklamaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HibeTutari = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurus", x => x.BasvuruId);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_BasvuranBirimId",
                        column: x => x.BasvuranBirimId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_BasvuruDonemiId",
                        column: x => x.BasvuruDonemiId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_BasvuruDurumuId",
                        column: x => x.BasvuruDurumuId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_BasvuruYapilanProjeId",
                        column: x => x.BasvuruYapilanProjeId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_BasvuruYapilanTurId",
                        column: x => x.BasvuruYapilanTurId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurus_TblRefs_KatilimciTuruId",
                        column: x => x.KatilimciTuruId,
                        principalTable: "TblRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasvuruKullanicis",
                columns: table => new
                {
                    BasvuruKullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BasvuruId = table.Column<int>(type: "integer", nullable: false),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasvuruKullanicis", x => x.BasvuruKullaniciId);
                    table.ForeignKey(
                        name: "FK_BasvuruKullanicis_Basvurus_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurus",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasvuruKullanicis_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasvuruKullanicis_BasvuruId",
                table: "BasvuruKullanicis",
                column: "BasvuruId");

            migrationBuilder.CreateIndex(
                name: "IX_BasvuruKullanicis_KullaniciId",
                table: "BasvuruKullanicis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuranBirimId",
                table: "Basvurus",
                column: "BasvuranBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuruDonemiId",
                table: "Basvurus",
                column: "BasvuruDonemiId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuruDurumuId",
                table: "Basvurus",
                column: "BasvuruDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuruYapilanProjeId",
                table: "Basvurus",
                column: "BasvuruYapilanProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_BasvuruYapilanTurId",
                table: "Basvurus",
                column: "BasvuruYapilanTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurus_KatilimciTuruId",
                table: "Basvurus",
                column: "KatilimciTuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasvuruKullanicis");

            migrationBuilder.DropTable(
                name: "Basvurus");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "TblRefs");
        }
    }
}
