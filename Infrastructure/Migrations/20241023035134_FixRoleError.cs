using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 23, 3, 51, 32, 829, DateTimeKind.Utc).AddTicks(3634), "$2a$11$pA6INsmAIm5Bw8/1GBycD.AEiq4oMbBKZxIeRa.v6b9hxbAi.XT.q" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash", "RoleId" },
                values: new object[] { new DateTime(2024, 10, 23, 3, 51, 33, 5, DateTimeKind.Utc).AddTicks(7513), "$2a$11$JsVi.J7UjjVoEX3eEh/zZu4.CJ9eXZZ8wSm8vxTwcbF1Cefbbr/ou", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreationDate", "PasswordHash", "RoleId" },
                values: new object[] { new DateTime(2024, 10, 20, 1, 49, 56, 176, DateTimeKind.Utc).AddTicks(41), "$2a$11$XCdkRAh8FhzWgJ6fMKOoN.VsJcXBx3rx0Qapx.F79dsCRm6DQRRvu", 1 });
        }
    }
}
