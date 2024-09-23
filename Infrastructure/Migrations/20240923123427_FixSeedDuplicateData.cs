using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedDuplicateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("E8390000-4208-30D0-EBBC-08DCDBA9B31F"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("1de7660a-5288-440c-af13-9914662f155c"), "", null, new DateTime(2024, 9, 23, 12, 34, 26, 856, DateTimeKind.Utc).AddTicks(9663), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$V29u1wJQ/dbZ3V2dxwWA0uUoB8M4ipnUhMEOsKz/BoGR6aRPWSouO", "", 1, "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("7cbe09ca-5ca2-4c89-9ef7-f2ae4b387e94"), "", null, new DateTime(2024, 9, 23, 12, 31, 46, 19, DateTimeKind.Utc).AddTicks(1279), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$jHSQVLCbyDRLFbVHZ0D/Z.mPS9PIKtGNaWOqeff6wMG34VbyWsZCC", "", 1, "Admin", null });
        }
    }
}
