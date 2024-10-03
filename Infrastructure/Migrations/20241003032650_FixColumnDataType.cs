using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CenterServices",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 3, 3, 26, 48, 754, DateTimeKind.Utc).AddTicks(9920), "$2a$11$ExVTov9UwLhEIJHisn5fuO0uLAwdFrUdr3esB6FpE2N8BsMiYvHK." });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 3, 3, 26, 48, 920, DateTimeKind.Utc).AddTicks(350), "$2a$11$wo2JkVdYTB46nn2ErknRg.aqYGXazND79.Juk3tydglAI2P4k1qQ." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CenterServices",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 57, 28, 893, DateTimeKind.Utc).AddTicks(1567), "$2a$11$r1KBScnqA.KOBNlJy1oNDOkq9bWcxMw71PK.VbbZR/Z1oIqunKZDe" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 29, 2, 57, 29, 61, DateTimeKind.Utc).AddTicks(8078), "$2a$11$nR7RVhdnRVzdT5YCLHCW8eqn.o7oiQWM3J1FjF5vCbE6ORM1quNmi" });
        }
    }
}
