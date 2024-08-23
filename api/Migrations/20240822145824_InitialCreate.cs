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
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Tipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tip = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    AltTip = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    TipKod = table.Column<int>(type: "INT", nullable: true),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Basvuru",
                columns: table => new
                {
                    BasvuruId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeAdi = table.Column<string>(type: "text", nullable: false),
                    BasvuranBirimId = table.Column<int>(type: "INT", nullable: false),
                    BasvuruYapilanProjeId = table.Column<int>(type: "INT", nullable: false),
                    BasvuruYapilanTurId = table.Column<int>(type: "INT", nullable: false),
                    KatilimciTuruId = table.Column<int>(type: "INT", nullable: false),
                    BasvuruDonemiId = table.Column<int>(type: "INT", nullable: false),
                    BasvuruDurumuId = table.Column<int>(type: "INT", nullable: false),
                    BasvuruTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AciklamaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HibeTutari = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvuru", x => x.BasvuruId);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_BasvuranBirimId",
                        column: x => x.BasvuranBirimId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_BasvuruDonemiId",
                        column: x => x.BasvuruDonemiId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_BasvuruDurumuId",
                        column: x => x.BasvuruDurumuId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_BasvuruYapilanProjeId",
                        column: x => x.BasvuruYapilanProjeId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_BasvuruYapilanTurId",
                        column: x => x.BasvuruYapilanTurId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvuru_Tipler_KatilimciTuruId",
                        column: x => x.KatilimciTuruId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasvuruKullanici",
                columns: table => new
                {
                    BasvuruKullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BasvuruId = table.Column<int>(type: "integer", nullable: false),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasvuruKullanici", x => x.BasvuruKullaniciId);
                    table.ForeignKey(
                        name: "FK_BasvuruKullanici_Basvuru_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvuru",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasvuruKullanici_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuranBirimId",
                table: "Basvuru",
                column: "BasvuranBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruDonemiId",
                table: "Basvuru",
                column: "BasvuruDonemiId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruDurumuId",
                table: "Basvuru",
                column: "BasvuruDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruYapilanProjeId",
                table: "Basvuru",
                column: "BasvuruYapilanProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruYapilanTurId",
                table: "Basvuru",
                column: "BasvuruYapilanTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_KatilimciTuruId",
                table: "Basvuru",
                column: "KatilimciTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_BasvuruKullanici_BasvuruId",
                table: "BasvuruKullanici",
                column: "BasvuruId");

            migrationBuilder.CreateIndex(
                name: "IX_BasvuruKullanici_KullaniciId",
                table: "BasvuruKullanici",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasvuruKullanici");

            migrationBuilder.DropTable(
                name: "Basvuru");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Tipler");
        }
    }
}
