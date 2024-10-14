using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingServiceLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiniumTravelRate",
                table: "TravelExpenses",
                newName: "MinimumTravelRate");

            migrationBuilder.RenameColumn(
                name: "MaxiumTravelRate",
                table: "TravelExpenses",
                newName: "MaximumTravelRate");

            migrationBuilder.AddColumn<string>(
                name: "ServiceLocation",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KoiImage",
                table: "Kois",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CenterServiceImage",
                table: "CenterServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceLocation",
                table: "ServiceTypes");

            migrationBuilder.RenameColumn(
                name: "MinimumTravelRate",
                table: "TravelExpenses",
                newName: "MiniumTravelRate");

            migrationBuilder.RenameColumn(
                name: "MaximumTravelRate",
                table: "TravelExpenses",
                newName: "MaxiumTravelRate");

            migrationBuilder.AlterColumn<string>(
                name: "KoiImage",
                table: "Kois",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CenterServiceImage",
                table: "CenterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 11, 12, 41, 16, 203, DateTimeKind.Utc).AddTicks(2234), "$2a$11$xTFdy1HmrYk7BH0xi7GmG.YGI2ZykVX5ndJYad8LExXExqkLioDZK" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 11, 12, 41, 16, 362, DateTimeKind.Utc).AddTicks(6249), "$2a$11$yfz1MzMWhnzqZvKFh4EuIeGULU2cpj8SdytiW8NMX45zu1Ok7K05y" });
        }
    }
}
