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
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolAdi = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
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
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolId = table.Column<int>(type: "int", nullable: true, defaultValue: 2),
                    KullaniciAdi = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sifre = table.Column<string>(type: "varchar(50)", nullable: false),
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AktiflikDurumu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanici_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id");
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
                    KullaniciId = table.Column<int>(type: "integer", nullable: true),
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
                    SilinmeDurumu = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvuru", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuranBirimId",
                        column: x => x.BasvuranBirimId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruDonemId",
                        column: x => x.BasvuruDonemId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruDurumId",
                        column: x => x.BasvuruDurumId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruYapilanProjeId",
                        column: x => x.BasvuruYapilanProjeId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_BasvuruYapilanTurId",
                        column: x => x.BasvuruYapilanTurId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_KatilimciTurId",
                        column: x => x.KatilimciTurId,
                        principalTable: "AltTip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvuru_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "RolAdi" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
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

            migrationBuilder.InsertData(
                table: "AltTip",
                columns: new[] { "Id", "Ad", "SilinmeDurumu", "TipId" },
                values: new object[,]
                {
                    { 1, "Bilgi İşlem", null, 1 },
                    { 2, "İnsan Kaynakları", null, 1 },
                    { 3, "Yatırım İşleri", null, 1 },
                    { 4, "Erasmus", null, 2 },
                    { 5, "Merkezi", null, 2 },
                    { 6, "Avrupa", null, 2 },
                    { 7, "Diğer", null, 2 },
                    { 8, "Gençlik", null, 3 },
                    { 9, "Yetişkin", null, 3 },
                    { 10, "Spor", null, 3 },
                    { 11, "Mesleki", null, 3 },
                    { 12, "Dijital", null, 3 },
                    { 13, "Diğer", null, 3 },
                    { 14, "Koordinatör", null, 4 },
                    { 15, "Ortak", null, 4 },
                    { 16, "R1", null, 5 },
                    { 17, "R2", null, 5 },
                    { 18, "R3", null, 5 },
                    { 19, "Kabul", null, 6 },
                    { 20, "Red", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Kullanici",
                columns: new[] { "Id", "AktiflikDurumu", "KullaniciAdi", "RolId", "Sifre" },
                values: new object[,]
                {
                    { 1, true, "admin", 1, "admin" },
                    { 2, true, "user", 2, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltTip_TipId",
                table: "AltTip",
                column: "TipId");

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
                name: "IX_Basvuru_KullaniciId",
                table: "Basvuru",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_RolId",
                table: "Kullanici",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basvuru");

            migrationBuilder.DropTable(
                name: "AltTip");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
