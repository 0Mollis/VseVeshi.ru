using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VseVeshi.ru.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserGiveIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Добавляем новый столбец типа string
            migrationBuilder.AddColumn<string>(
                name: "UserGiveIdString",
                table: "RentItems",
                type: "nvarchar(255)",
                nullable: true);

            // 2. Копируем данные из старого столбца в новый, преобразуя int в string
            migrationBuilder.Sql("UPDATE RentItems SET UserGiveIdString = CAST(userGiveId AS NVARCHAR(255))");

            // 3. Удаляем старый столбец int
            migrationBuilder.DropColumn(
                name: "userGiveId",
                table: "RentItems");

            // 4. Переименовываем новый столбец string в userGiveId
            migrationBuilder.RenameColumn(
                name: "UserGiveIdString",
                table: "RentItems",
                newName: "userGiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Добавляем старый столбец типа int
            migrationBuilder.AddColumn<int>(
                name: "userGiveIdInt",
                table: "RentItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // 2. Копируем данные из нового столбца в старый, преобразуя string в int (обратите внимание на обработку ошибок!)
            migrationBuilder.Sql(@"
                UPDATE RentItems
                SET userGiveIdInt = CASE
                    WHEN ISNUMERIC(userGiveId) = 1 THEN CAST(userGiveId AS INT)
                    ELSE 0  -- Или другое значение по умолчанию, если преобразование невозможно
                END");

            // 3. Удаляем новый столбец string
            migrationBuilder.DropColumn(
                name: "userGiveId",
                table: "RentItems");

            // 4. Переименовываем старый столбец int в userGiveId
            migrationBuilder.RenameColumn(
                name: "userGiveIdInt",
                table: "RentItems",
                newName: "userGiveId");
        }
    }
}
