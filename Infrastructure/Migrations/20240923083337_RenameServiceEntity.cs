using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameServiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Services",
                newName: "CenterServices"
                );
            /*migrationBuilder.DropForeignKey(
                name: "FK_CenterServices_CenterTanks_CenterTankId",
                table: "CenterServices");*/

            /*migrationBuilder.DropIndex(
                name: "IX_CenterServices_CenterTankId",
                table: "CenterServices");*/

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("E8390000-4208-30D0-EBBC-08DCDBA9B31F"));

            /* migrationBuilder.DropColumn(
                 name: "CenterTankId",
                 table: "CenterServices");*/

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("af29f656-eb16-410c-a7ab-3f7c56d88e32"), "", null, new DateTime(2024, 9, 23, 8, 33, 37, 335, DateTimeKind.Utc).AddTicks(2453), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$C/ogfzxlye2ZxB8GDUOny.vNgiGMhz1dFgfzeq1gBZwHiKebBGBLS", "", 1, "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_CenterServices_TankId",
                table: "CenterServices",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterServices_CenterTanks_TankId",
                table: "CenterServices",
                column: "TankId",
                principalTable: "CenterTanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CenterServices_CenterTanks_TankId",
                table: "CenterServices");

            migrationBuilder.DropIndex(
                name: "IX_CenterServices_TankId",
                table: "CenterServices");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("af29f656-eb16-410c-a7ab-3f7c56d88e32"));

            migrationBuilder.AddColumn<Guid>(
                name: "CenterTankId",
                table: "CenterServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("981e0000-4208-30d0-15c0-08dcdba9ecf3"), "", null, new DateTime(2024, 9, 23, 8, 30, 5, 280, DateTimeKind.Utc).AddTicks(1121), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$KPdkPf5OQ1kXwVPySHF7beSAj9LuoifViAV8kDOhZVbrC7wmpgi5K", "", 1, "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_CenterServices_CenterTankId",
                table: "CenterServices",
                column: "CenterTankId");

            migrationBuilder.AddForeignKey(
                name: "FK_CenterServices_CenterTanks_CenterTankId",
                table: "CenterServices",
                column: "CenterTankId",
                principalTable: "CenterTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
