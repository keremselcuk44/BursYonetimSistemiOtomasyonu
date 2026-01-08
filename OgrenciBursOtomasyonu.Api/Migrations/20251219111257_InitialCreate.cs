using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BursAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MinimumPuan = table.Column<int>(type: "int", nullable: false),
                    Kontenjan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burslar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Universite = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bolum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    AileGeliri = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NedenBurs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaddiDurumAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GelecekHedefleri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciBurslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    BursId = table.Column<int>(type: "int", nullable: false),
                    Onaylandi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciBurslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciBurslar_Burslar_BursId",
                        column: x => x.BursId,
                        principalTable: "Burslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciBurslar_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciBurslar_BursId",
                table: "OgrenciBurslar",
                column: "BursId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciBurslar_OgrenciId",
                table: "OgrenciBurslar",
                column: "OgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciBurslar");

            migrationBuilder.DropTable(
                name: "Burslar");

            migrationBuilder.DropTable(
                name: "Ogrenciler");
        }
    }
}
