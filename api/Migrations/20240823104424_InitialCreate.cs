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
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    Sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AltTipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true),
                    TipId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltTipler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltTipler_Tipler_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basvurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BasvuruAdi = table.Column<string>(type: "text", nullable: false),
                    BasvuruDurumId = table.Column<int>(type: "integer", nullable: false),
                    BasvuruYapilanProjeId = table.Column<int>(type: "integer", nullable: false),
                    BasvuruYapilanTurId = table.Column<int>(type: "integer", nullable: false),
                    AltTipId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basvurular_AltTipler_AltTipId",
                        column: x => x.AltTipId,
                        principalTable: "AltTipler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Basvurular_Tipler_BasvuruDurumId",
                        column: x => x.BasvuruDurumId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurular_Tipler_BasvuruYapilanProjeId",
                        column: x => x.BasvuruYapilanProjeId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basvurular_Tipler_BasvuruYapilanTurId",
                        column: x => x.BasvuruYapilanTurId,
                        principalTable: "Tipler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciBasvurular",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    BasvuruId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciBasvurular", x => new { x.KullaniciId, x.BasvuruId });
                    table.ForeignKey(
                        name: "FK_KullaniciBasvurular_Basvurular_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciBasvurular_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltTipler_TipId",
                table: "AltTipler",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_AltTipId",
                table: "Basvurular",
                column: "AltTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_BasvuruDurumId",
                table: "Basvurular",
                column: "BasvuruDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_BasvuruYapilanProjeId",
                table: "Basvurular",
                column: "BasvuruYapilanProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_BasvuruYapilanTurId",
                table: "Basvurular",
                column: "BasvuruYapilanTurId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciBasvurular_BasvuruId",
                table: "KullaniciBasvurular",
                column: "BasvuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciBasvurular");

            migrationBuilder.DropTable(
                name: "Basvurular");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "AltTipler");

            migrationBuilder.DropTable(
                name: "Tipler");
        }
    }
}
