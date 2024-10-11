using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToCenterService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CenterServiceImage",
                table: "CenterServices",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 11, 12, 41, 16, 203, DateTimeKind.Utc).AddTicks(2234), "$2a$11$xTFdy1HmrYk7BH0xi7GmG.YGI2ZykVX5ndJYad8LExXExqkLioDZK" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 11, 12, 41, 16, 362, DateTimeKind.Utc).AddTicks(6249), "$2a$11$yfz1MzMWhnzqZvKFh4EuIeGULU2cpj8SdytiW8NMX45zu1Ok7K05y" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterServiceImage",
                table: "CenterServices");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 5, 11, 16, 48, 580, DateTimeKind.Utc).AddTicks(27), "$2a$11$y0O6VsnB.q9wdTnnjlcgF.vwMztcnzwwqgNetOObajaxJtpC8j2/6" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 5, 11, 16, 48, 768, DateTimeKind.Utc).AddTicks(1494), "$2a$11$agr3qCGLCo7HiF2fF.9E1ukYvlcyO21E3e8QagVYwJ5.71ZEX589K" });
        }
    }
}
