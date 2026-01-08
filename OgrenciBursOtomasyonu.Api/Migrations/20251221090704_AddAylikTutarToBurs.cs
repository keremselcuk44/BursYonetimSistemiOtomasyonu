using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAylikTutarToBurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AylikTutar",
                table: "Burslar",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AylikTutar",
                table: "Burslar");
        }
    }
}
