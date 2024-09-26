using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAttributeToEntity_ver02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KoiImage",
                table: "Kois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VeterinarianId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash", "ProfileImage" },
                values: new object[] { new DateTime(2024, 9, 26, 9, 32, 2, 877, DateTimeKind.Utc).AddTicks(6401), "$2a$11$IfO58nWnh3qi93ACWn6LBu0SZZC93HZRLidWBUvd4VT8IZaJHz0O6", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash", "ProfileImage" },
                values: new object[] { new DateTime(2024, 9, 26, 9, 32, 3, 59, DateTimeKind.Utc).AddTicks(1222), "$2a$11$xx2C68XM9JdTfDFyDp44tu9/qcqeD3AaCXUmDJbHe2jXMvJWxg8eK", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KoiImage",
                table: "Kois");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Accounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeterinarianId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
        }
    }
}
