using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VseVeshi.ru.Data.Migrations
{
    /// <inheritdoc />
    public partial class _027 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RentItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "brand",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "color",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RentItems");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "RentItems");

            migrationBuilder.DropColumn(
                name: "color",
                table: "RentItems");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "RentItems");

            migrationBuilder.DropColumn(
                name: "type",
                table: "RentItems");
        }
    }
}
