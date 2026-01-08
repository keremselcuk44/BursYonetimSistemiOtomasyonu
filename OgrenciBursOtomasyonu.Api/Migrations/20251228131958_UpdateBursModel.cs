using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciBursOtomasyonu.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBursModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Burslar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Burslar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Burslar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
                table: "Burslar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BursTipi",
                table: "Burslar",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Burslar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kosullar",
                table: "Burslar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OdemePeriyodu",
                table: "Burslar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturmaTarihi",
                table: "Burslar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "BaslangicTarihi",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "BursTipi",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "Kosullar",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "OdemePeriyodu",
                table: "Burslar");

            migrationBuilder.DropColumn(
                name: "OlusturmaTarihi",
                table: "Burslar");
        }
    }
}
