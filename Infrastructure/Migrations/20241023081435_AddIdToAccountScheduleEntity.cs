using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToAccountScheduleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AccountSchedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 8, 14, 33, 959, DateTimeKind.Utc).AddTicks(9515), "$2a$11$WCdQc5z4CwHcIqZ7xwL3geKaDuNWZNqYFH34UEqb4WjEgswnzo1eK" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 8, 14, 34, 147, DateTimeKind.Utc).AddTicks(9640), "$2a$11$9HNjkZoRYDt2e0Nw1HlMO.04ss4CRPWO1plcIGDtVQWxBLShyYiBq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccountSchedules");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 3, 51, 32, 829, DateTimeKind.Utc).AddTicks(3634), "$2a$11$pA6INsmAIm5Bw8/1GBycD.AEiq4oMbBKZxIeRa.v6b9hxbAi.XT.q" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 3, 51, 33, 5, DateTimeKind.Utc).AddTicks(7513), "$2a$11$JsVi.J7UjjVoEX3eEh/zZu4.CJ9eXZZ8wSm8vxTwcbF1Cefbbr/ou" });
        }
    }
}
