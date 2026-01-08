using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOgrenciModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AileGeliri",
                table: "Ogrenciler");

            migrationBuilder.RenameColumn(
                name: "NedenBurs",
                table: "Ogrenciler",
                newName: "ToplumaKatki");

            migrationBuilder.RenameColumn(
                name: "MaddiDurumAciklama",
                table: "Ogrenciler",
                newName: "EgitimMasraflari");

            migrationBuilder.RenameColumn(
                name: "GelecekHedefleri",
                table: "Ogrenciler",
                newName: "BursAlmaIhtiyaci");

            migrationBuilder.AlterColumn<string>(
                name: "Sinif",
                table: "Ogrenciler",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Agno",
                table: "Ogrenciler",
                type: "decimal(4,2)",
                precision: 4,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AiRaporu",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AkademikGelisim",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BesYilSonrasi",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "HaneGeliri",
                table: "Ogrenciler",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "KardesSayisi",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agno",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "AiRaporu",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "AkademikGelisim",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "BesYilSonrasi",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "HaneGeliri",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "KardesSayisi",
                table: "Ogrenciler");

            migrationBuilder.RenameColumn(
                name: "ToplumaKatki",
                table: "Ogrenciler",
                newName: "NedenBurs");

            migrationBuilder.RenameColumn(
                name: "EgitimMasraflari",
                table: "Ogrenciler",
                newName: "MaddiDurumAciklama");

            migrationBuilder.RenameColumn(
                name: "BursAlmaIhtiyaci",
                table: "Ogrenciler",
                newName: "GelecekHedefleri");

            migrationBuilder.AlterColumn<int>(
                name: "Sinif",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "AileGeliri",
                table: "Ogrenciler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
