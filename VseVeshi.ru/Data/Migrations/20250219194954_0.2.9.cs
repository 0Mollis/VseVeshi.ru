using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VseVeshi.ru.Data.Migrations
{
    /// <inheritdoc />
    public partial class _029 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userGiveId",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userGiveId",
                table: "RentItems");
        }
    }
}
