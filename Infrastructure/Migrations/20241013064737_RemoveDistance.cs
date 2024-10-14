using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDistance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "TravelExpenses");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 6, 47, 36, 573, DateTimeKind.Utc).AddTicks(7287), "$2a$11$2pEioyBxZNLe1M0eUQhc4.GcKY4EVGicz8YhcvU6ElicaZm6MD.Ue" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 6, 47, 36, 749, DateTimeKind.Utc).AddTicks(7175), "$2a$11$nwnkRqABC/keRd.5lQgBV.A7GeD60pwh9eSP9OHyL6o.xYYwXk.QG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Distance",
                table: "TravelExpenses",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 6, 35, 51, 42, DateTimeKind.Utc).AddTicks(7971), "$2a$11$98XTyQgivXdfEhPl8JQlvuymSpcIdy6L5JkwYc9vSPjVUexd8MFj2" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 13, 6, 35, 51, 266, DateTimeKind.Utc).AddTicks(965), "$2a$11$XCU8GBxmN9fGm14v8ERghemXjAh1amTaoUb0s6IE./Szj3lSsoowS" });
        }
    }
}
