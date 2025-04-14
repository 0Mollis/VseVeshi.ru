using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VseVeshi.ru.Data.Migrations
{
    /// <inheritdoc />
    public partial class _60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfRegistration",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfRegistration",
                table: "AspNetUsers");
        }
    }
}
