using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTelefonIbanResimToOgrenci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Ogrenciler",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResimYolu",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Ogrenciler",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "ResimYolu",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Ogrenciler");
        }
    }
}
