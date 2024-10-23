using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountSchedules",
                table: "AccountSchedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountSchedules",
                table: "AccountSchedules",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountSchedules_AccountId",
                table: "AccountSchedules",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountSchedules",
                table: "AccountSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AccountSchedules_AccountId",
                table: "AccountSchedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountSchedules",
                table: "AccountSchedules",
                columns: new[] { "AccountId", "ScheduleId" });

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
    }
}
