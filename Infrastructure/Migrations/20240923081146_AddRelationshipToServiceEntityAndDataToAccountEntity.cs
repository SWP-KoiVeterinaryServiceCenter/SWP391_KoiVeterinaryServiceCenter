using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipToServiceEntityAndDataToAccountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CenterTanks_CenterTankId",
                table: "Services");

           /* migrationBuilder.AlterColumn<Guid>(
                name: "CenterTankId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);*/

            migrationBuilder.AddColumn<Guid>(
                name: "TankId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ContactLink", "CreatedBy", "CreationDate", "DeletedBy", "DeletionDate", "Email", "Fullname", "IsDelete", "Location", "ModificationBy", "ModificationDate", "PasswordHash", "Phonenumber", "RoleId", "Username", "WorkingScheduleId" },
                values: new object[] { new Guid("ec340000-4208-30d0-0b8d-08dcdba75ce7"), "", null, new DateTime(2024, 9, 23, 8, 11, 44, 669, DateTimeKind.Utc).AddTicks(3521), null, null, "admin@gmail.com", "Admin", false, "", null, null, "$2a$11$QQZ.ULOpY.n8iv7qjm.lYOZLcRiZDzxKGFPMIpMBr4mdcUf5XueT2", "", 1, "Admin", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CenterTanks_TankId",
                table: "Services",
                column: "TankId",
                principalTable: "CenterTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CenterTanks_CenterTankId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("ec340000-4208-30d0-0b8d-08dcdba75ce7"));

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Services");

            migrationBuilder.AlterColumn<Guid>(
                name: "CenterTankId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CenterTanks_CenterTankId",
                table: "Services",
                column: "CenterTankId",
                principalTable: "CenterTanks",
                principalColumn: "Id");
        }
    }
}
