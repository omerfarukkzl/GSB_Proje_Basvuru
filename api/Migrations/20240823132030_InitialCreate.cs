using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sifre = table.Column<string>(type: "varchar(50)", nullable: false),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "varchar(50)", nullable: true),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AltTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipId = table.Column<int>(type: "int", nullable: true),
                    Ad = table.Column<string>(type: "varchar(50)", nullable: true),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltTip_TipId",
                        column: x => x.TipId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Basvuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeAdi = table.Column<string>(type: "varchar(50)", nullable: true),
                    BasvuranBirimId = table.Column<int>(type: "int", nullable: true),
                    BasvuruYapilanProjeId = table.Column<int>(type: "int", nullable: true),
                    BasvuruYapilanTurId = table.Column<int>(type: "int", nullable: true),
                    KatilimciTurId = table.Column<int>(type: "int", nullable: true),
                    BasvuruDonemId = table.Column<int>(type: "int", nullable: true),
                    BasvuruDurumId = table.Column<int>(type: "int", nullable: true),
                    BasvuruTarihi = table.Column<DateTime>(type: "timestamp", nullable: true),
                    AciklanmaTarihi = table.Column<DateTime>(type: "timestamp", nullable: true),
                    HibeTutari = table.Column<decimal>(type: "decimal", nullable: true),
                    AltTipId = table.Column<int>(type: "integer", nullable: true),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvuru", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basvuru_AltTip_AltTipId",
                        column: x => x.AltTipId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruDonemId",
                        column: x => x.BasvuruDonemId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruDurumId",
                        column: x => x.BasvuruDurumId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruYapilanProjeId",
                        column: x => x.BasvuruYapilanProjeId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruYapilanTurId",
                        column: x => x.BasvuruYapilanTurId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_KatilimciTurId",
                        column: x => x.KatilimciTurId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_Tip_BasvuranBirimId",
                        column: x => x.BasvuranBirimId,
                        principalTable: "Tip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciBasvuru",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BasvuruId = table.Column<int>(type: "int", nullable: false),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciBasvuru", x => new { x.KullaniciId, x.BasvuruId });
                    table.ForeignKey(
                        name: "FK_KullaniciBasvuru_Basvuru_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvuru",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciBasvuru_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tip",
                columns: new[] { "Id", "Ad", "SilinmeDurumu" },
                values: new object[,]
                {
                    { 1, "Başvuran Birim", null },
                    { 2, "Basvuru Yapılan Proje", null },
                    { 3, "Başvuru Yapılan Tür", null },
                    { 4, "Katılımcı Türü", null },
                    { 5, "Başvuru Dönemi", null },
                    { 6, "Başvuru Durumu", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltTip_TipId",
                table: "AltTip",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_AltTipId",
                table: "Basvuru",
                column: "AltTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuranBirimId",
                table: "Basvuru",
                column: "BasvuranBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruDonemId",
                table: "Basvuru",
                column: "BasvuruDonemId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruDurumId",
                table: "Basvuru",
                column: "BasvuruDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruYapilanProjeId",
                table: "Basvuru",
                column: "BasvuruYapilanProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_BasvuruYapilanTurId",
                table: "Basvuru",
                column: "BasvuruYapilanTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_KatilimciTurId",
                table: "Basvuru",
                column: "KatilimciTurId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciBasvuru_BasvuruId",
                table: "KullaniciBasvuru",
                column: "BasvuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciBasvuru");

            migrationBuilder.DropTable(
                name: "Basvuru");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "AltTip");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
