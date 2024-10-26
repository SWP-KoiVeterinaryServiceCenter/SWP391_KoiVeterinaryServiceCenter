using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatingContent",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 32, 8, 282, DateTimeKind.Utc).AddTicks(1112), "$2a$11$Kq7gnVaNgCNPhgSWX7lvK.3SZaILNss7QjZpB1us0ZXhzMf86h3Di" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 32, 8, 527, DateTimeKind.Utc).AddTicks(3250), "$2a$11$Mpg1v5pV2qgfUlO2YwB1HOon6d6jYaikkxpVkVG2.mhRIJTfsW0/6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingContent",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 8, 19, 35, 31, DateTimeKind.Utc).AddTicks(7540), "$2a$11$DuPVyS/2NDIrPD7GWwOLKOW29DLCbgv8uJ7SV.gMDfJjqMdQm6s4K" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 8, 19, 35, 215, DateTimeKind.Utc).AddTicks(6422), "$2a$11$6ZJrnMxjEmNqBl7DJ6nzIuYK2FXonplct4ExXIhHuUqwUg.KJKQzK" });
        }
    }
}
