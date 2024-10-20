using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountScheduleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_WorkingSchedules_WorkingScheduleId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WorkingScheduleId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "WorkingScheduleId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "AccountSchedules",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSchedules", x => new { x.AccountId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_AccountSchedules_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSchedules_WorkingSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "WorkingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 20, 1, 49, 55, 987, DateTimeKind.Utc).AddTicks(6822), "$2a$11$cLWfqN.8.z1DVJjKAdsY7e9L9oDM9D26iRNQnJiijubCsCn1.Q8P." });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 20, 1, 49, 56, 176, DateTimeKind.Utc).AddTicks(41), "$2a$11$XCdkRAh8FhzWgJ6fMKOoN.VsJcXBx3rx0Qapx.F79dsCRm6DQRRvu" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountSchedules_ScheduleId",
                table: "AccountSchedules",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSchedules");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkingScheduleId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash", "WorkingScheduleId" },
                values: new object[] { new DateTime(2024, 10, 19, 8, 48, 49, 509, DateTimeKind.Utc).AddTicks(5831), "$2a$11$ULrZigRBu5hkqmq.8WqTv.K9FGZsncEYF2wCPN5S7VcfbVmdTMUKa", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash", "WorkingScheduleId" },
                values: new object[] { new DateTime(2024, 10, 19, 8, 48, 49, 714, DateTimeKind.Utc).AddTicks(6244), "$2a$11$CKtAqpyGGEVIATUHIH1Oaerasf.2YM422F/LUEXXJNGf7XWWJCZrW", null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WorkingScheduleId",
                table: "Accounts",
                column: "WorkingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_WorkingSchedules_WorkingScheduleId",
                table: "Accounts",
                column: "WorkingScheduleId",
                principalTable: "WorkingSchedules",
                principalColumn: "Id");
        }
    }
}
