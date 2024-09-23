using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaffData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 23, 13, 19, 37, 534, DateTimeKind.Utc).AddTicks(8909), "$2a$11$f9DpR4XMOZg4ppfolb.a2.weu.A8G5W6rMXs3qTnn.SoWmTUpV6KW" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"), "", null, new DateTime(2024, 9, 23, 13, 19, 37, 715, DateTimeKind.Utc).AddTicks(5835), null, null, "staff@gmail.com", "Staff", false, "", null, null, "$2a$11$0e9fqQ8x7WXuJN6HNkNUCO8lxdxSOskf.VMeZuFb61QMbzk8UT1T.", "", 1, "Staff", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 23, 12, 34, 26, 856, DateTimeKind.Utc).AddTicks(9663), "$2a$11$V29u1wJQ/dbZ3V2dxwWA0uUoB8M4ipnUhMEOsKz/BoGR6aRPWSouO" });
        }
    }
}
