using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceLocationToCenterService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceLocation",
                table: "ServiceTypes");

            migrationBuilder.AddColumn<string>(
                name: "ServiceLocation",
                table: "CenterServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 18, 12, 3, 51, 948, DateTimeKind.Utc).AddTicks(1660), "$2a$11$RrpZaD66TrwC5dze3le8q.4IuFR6k4tkcf9j3Y5wj.1JtPMUvQXRm" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 18, 12, 3, 52, 196, DateTimeKind.Utc).AddTicks(9889), "$2a$11$0RWCxBD1D8rDemw1mOH3Y.uxWBhQbf4mAQfDpHa3Ao4MAl7.ZS7Wm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceLocation",
                table: "CenterServices");

            migrationBuilder.AddColumn<string>(
                name: "ServiceLocation",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
