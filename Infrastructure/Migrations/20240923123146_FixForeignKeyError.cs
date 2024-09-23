using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "CenterServices");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypeId",
                table: "CenterServices");

            /*migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("af29f656-eb16-410c-a7ab-3f7c56d88e32"));*/

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "CenterServices");

          /*  migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("7cbe09ca-5ca2-4c89-9ef7-f2ae4b387e94"), "", null, new DateTime(2024, 9, 23, 12, 31, 46, 19, DateTimeKind.Utc).AddTicks(1279), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$jHSQVLCbyDRLFbVHZ0D/Z.mPS9PIKtGNaWOqeff6wMG34VbyWsZCC", "", 1, "Admin", null });*/

            migrationBuilder.CreateIndex(
                name: "IX_CenterServices_TypeId",
                table: "CenterServices",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterServices_ServiceTypes_TypeId",
                table: "CenterServices",
                column: "TypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CenterServices_ServiceTypes_TypeId",
                table: "CenterServices");

            migrationBuilder.DropIndex(
                name: "IX_CenterServices_TypeId",
                table: "CenterServices");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("7cbe09ca-5ca2-4c89-9ef7-f2ae4b387e94"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceTypeId",
                table: "CenterServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("af29f656-eb16-410c-a7ab-3f7c56d88e32"), "", null, new DateTime(2024, 9, 23, 8, 33, 37, 335, DateTimeKind.Utc).AddTicks(2453), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$C/ogfzxlye2ZxB8GDUOny.vNgiGMhz1dFgfzeq1gBZwHiKebBGBLS", "", 1, "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_CenterServices_ServiceTypeId",
                table: "CenterServices",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterServices_ServiceTypes_ServiceTypeId",
                table: "CenterServices",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
