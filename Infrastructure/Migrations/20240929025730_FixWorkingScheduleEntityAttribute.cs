using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkingScheduleEntityAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WorkingSchedules");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "WorkingSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "WorkingSchedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingDay",
                table: "WorkingSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingDay",
                table: "WorkingSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WorkingSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "WorkingSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "WorkingSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 9, 32, 2, 877, DateTimeKind.Utc).AddTicks(6401), "$2a$11$IfO58nWnh3qi93ACWn6LBu0SZZC93HZRLidWBUvd4VT8IZaJHz0O6" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 9, 32, 3, 59, DateTimeKind.Utc).AddTicks(1222), "$2a$11$xx2C68XM9JdTfDFyDp44tu9/qcqeD3AaCXUmDJbHe2jXMvJWxg8eK" });
        }
    }
}
