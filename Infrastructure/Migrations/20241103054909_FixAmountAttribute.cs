using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAmountAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(15,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 3, 5, 49, 8, 356, DateTimeKind.Utc).AddTicks(751), "$2a$11$BeKKTyRx6zC9tq9Rf4ywgeb5JXWKbl2p5ltw2wOLl7Oi28hvSZnta" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 3, 5, 49, 8, 577, DateTimeKind.Utc).AddTicks(1499), "$2a$11$CsYXUycY7yml8.pVQ/WebuYjbRPM8fli.A9hmuS1pNjOkd7Bw3pNi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Transactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 3, 4, 0, 20, 965, DateTimeKind.Utc).AddTicks(6749), "$2a$11$/7Lk01Gq31ZzKTNbTnIg4OFa7t.WW1QY5WnR/zr4yPfwwfs1hRVXG" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 3, 4, 0, 21, 166, DateTimeKind.Utc).AddTicks(9897), "$2a$11$oPLaJJ/eY7OY2uTorC93k.UTMiLVKJBeKjOqSi5CkwPezAkq39vba" });
        }
    }
}
