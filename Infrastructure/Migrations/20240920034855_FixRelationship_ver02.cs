using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship_ver02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_MedicalRecords_MedicalRecordId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_MedicalRecordId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Services");

            migrationBuilder.AddColumn<Guid>(
                name: "KoiId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_KoiId",
                table: "Appointments",
                column: "KoiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Kois_KoiId",
                table: "Appointments",
                column: "KoiId",
                principalTable: "Kois",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Kois_KoiId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_KoiId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "KoiId",
                table: "Appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalRecordId",
                table: "Services",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_MedicalRecordId",
                table: "Services",
                column: "MedicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_MedicalRecords_MedicalRecordId",
                table: "Services",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }
    }
}
