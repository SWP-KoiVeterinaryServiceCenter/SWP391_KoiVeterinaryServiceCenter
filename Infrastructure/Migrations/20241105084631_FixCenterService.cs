using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCenterService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 5, 8, 46, 29, 265, DateTimeKind.Utc).AddTicks(4373), "$2a$11$x/Fm8HPHZmEopZxQfE/N4uhk9NiggCbSZIanyIh7a5PU91iaNklF2" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 11, 5, 8, 46, 29, 461, DateTimeKind.Utc).AddTicks(8075), "$2a$11$0njfQjiATvrcn.iuHl80Cu8WBthnGY1jfWTl3d/.rfeSxyZNJ19A2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
