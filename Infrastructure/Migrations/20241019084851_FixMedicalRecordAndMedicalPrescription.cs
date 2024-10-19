using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMedicalRecordAndMedicalPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Appointments_AppointmentId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalPrescriptions_MedicalRecordId",
                table: "MedicalPrescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalPrescriptionId",
                table: "MedicalRecords");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestResults",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreatmentGiven",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "MedicalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "MedicalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "MedicalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "MedicalPrescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 19, 8, 48, 49, 509, DateTimeKind.Utc).AddTicks(5831), "$2a$11$ULrZigRBu5hkqmq.8WqTv.K9FGZsncEYF2wCPN5S7VcfbVmdTMUKa" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 19, 8, 48, 49, 714, DateTimeKind.Utc).AddTicks(6244), "$2a$11$CKtAqpyGGEVIATUHIH1Oaerasf.2YM422F/LUEXXJNGf7XWWJCZrW" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPrescriptions_MedicalRecordId",
                table: "MedicalPrescriptions",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicalRecordId",
                table: "Appointments",
                column: "MedicalRecordId",
                unique: true,
                filter: "[MedicalRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_MedicalRecords_MedicalRecordId",
                table: "Appointments",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_MedicalRecords_MedicalRecordId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalPrescriptions_MedicalRecordId",
                table: "MedicalPrescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_MedicalRecordId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "TestResults",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "TreatmentGiven",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "MedicalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "MedicalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "MedicalPrescriptions");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "MedicalPrescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalPrescriptionId",
                table: "MedicalRecords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 18, 12, 3, 51, 948, DateTimeKind.Utc).AddTicks(1660), "$2a$11$RrpZaD66TrwC5dze3le8q.4IuFR6k4tkcf9j3Y5wj.1JtPMUvQXRm" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                columns: new[] { "CreationDate", "PasswordHash" },
                values: new object[] { new DateTime(2024, 10, 18, 12, 3, 52, 196, DateTimeKind.Utc).AddTicks(9889), "$2a$11$0RWCxBD1D8rDemw1mOH3Y.uxWBhQbf4mAQfDpHa3Ao4MAl7.ZS7Wm" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPrescriptions_MedicalRecordId",
                table: "MedicalPrescriptions",
                column: "MedicalRecordId",
                unique: true,
                filter: "[MedicalRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Appointments_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
