using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAttributeToEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VeterinarianId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 8, 46, 52, 411, DateTimeKind.Utc).AddTicks(567), "$2a$11$mT3WB.Zhe2MWV1e4dF2rvOuQqkOjEXEpb4588H59ejQsemqzitMa." });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 8, 46, 52, 581, DateTimeKind.Utc).AddTicks(7527), "$2a$11$G/eqLFRTCStDvvzNsySA5OWi4pr9oP/NR3syNxp17voNWMtWLz876" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "RoleName",
                value: "Veterinarian");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 3, 24, 27, 722, DateTimeKind.Utc).AddTicks(2499), "$2a$11$GkA8j9splf1Ze2reaa0N4OHUM9vR35zJgRjG4Hdd0ihkgkdHScGiO" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 26, 3, 24, 27, 897, DateTimeKind.Utc).AddTicks(9756), "$2a$11$BP8Hfc4Ky8ombI1gPChn0ua5AvtzwRS7Y7X7Ak4z3zEtSFHNEPyMq" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "RoleName",
                value: "Veterian");
        }
    }
}
