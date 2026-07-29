using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCity.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class softdelet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Owners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Owners",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Owners");
        }
    }
}
