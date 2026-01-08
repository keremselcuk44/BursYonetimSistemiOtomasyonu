using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOnayDurumuToOgrenci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnayDurumu",
                table: "Ogrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnayDurumu",
                table: "Ogrenciler");
        }
    }
}
