using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeKoiImageNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KoiImage",
                table: "Kois",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 9, 31, 46, 501, DateTimeKind.Utc).AddTicks(6358), "$2a$11$.vwUIkd8QOFKoJzhzqSu9uhMRgWKlriSnUUWf4B7BKkZTtyd.9xdu" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 9, 31, 46, 684, DateTimeKind.Utc).AddTicks(1418), "$2a$11$n1c55dGKfuNQg3rYKlqMOueb3jhMPTAvV.G72gJVbSunbrS1eqBzO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KoiImage",
                table: "Kois",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 9, 30, 2, 374, DateTimeKind.Utc).AddTicks(5699), "$2a$11$h3QK9nGcETVpGFM2jP5A7.k4A5zNfduQxpscDGZfIYzWjn99F/T.i" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 9, 30, 2, 569, DateTimeKind.Utc).AddTicks(4650), "$2a$11$OAV28sou8ZYgHJCOUnmWxeW3De5rcYwKetXR22szkqXa6itkkBMdG" });
        }
    }
}
