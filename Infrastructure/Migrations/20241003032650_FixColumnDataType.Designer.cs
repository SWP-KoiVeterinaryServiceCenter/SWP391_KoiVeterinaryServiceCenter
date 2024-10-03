﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241003032650_FixColumnDataType")]
    partial class FixColumnDataType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkingScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkingScheduleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1de7660a-5288-440c-af13-9914662f155c"),
                            ContactLink = "",
                            CreationDate = new DateTime(2024, 10, 3, 3, 26, 48, 754, DateTimeKind.Utc).AddTicks(9920),
                            Email = "admin@gmail.com",
                            Fullname = "Admin",
                            IsDelete = false,
                            Location = "",
                            PasswordHash = "$2a$11$ExVTov9UwLhEIJHisn5fuO0uLAwdFrUdr3esB6FpE2N8BsMiYvHK.",
                            Phonenumber = "",
                            RoleId = 1,
                            Username = "Admin"
                        },
                        new
                        {
                            Id = new Guid("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                            ContactLink = "",
                            CreationDate = new DateTime(2024, 10, 3, 3, 26, 48, 920, DateTimeKind.Utc).AddTicks(350),
                            Email = "staff@gmail.com",
                            Fullname = "Staff",
                            IsDelete = false,
                            Location = "",
                            PasswordHash = "$2a$11$wo2JkVdYTB46nn2ErknRg.aqYGXazND79.Juk3tydglAI2P4k1qQ.",
                            Phonenumber = "",
                            RoleId = 1,
                            Username = "Staff"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppointmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FeedbackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RatingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VeterinarianId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("KoiId");

                    b.HasIndex("ServiceId")
                        .IsUnique()
                        .HasFilter("[ServiceId] IS NOT NULL");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.CenterService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TankId");

                    b.HasIndex("TypeId");

                    b.ToTable("CenterServices");
                });

            modelBuilder.Entity("Domain.Entities.CenterTank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CenterTanks");
                });

            modelBuilder.Entity("Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AppointmentId")
                        .IsUnique()
                        .HasFilter("[AppointmentId] IS NOT NULL");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Domain.Entities.Koi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("KoiImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KoiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Varieties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Kois");
                });

            modelBuilder.Entity("Domain.Entities.MedicalPrescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MedicalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId")
                        .IsUnique()
                        .HasFilter("[MedicalRecordId] IS NOT NULL");

                    b.ToTable("MedicalPrescriptions");
                });

            modelBuilder.Entity("Domain.Entities.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MedicalPrescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique()
                        .HasFilter("[AppointmentId] IS NOT NULL");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("RaterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("RatingPoint")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique()
                        .HasFilter("[AppointmentId] IS NOT NULL");

                    b.HasIndex("RaterId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Veterinarian"
                        },
                        new
                        {
                            RoleId = 4,
                            RoleName = "Customer"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TravelExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TravelExpenseId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Domain.Entities.TravelExpense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BaseRate")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(5,2)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxiumTravelRate")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("MiniumTravelRate")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TravelExpenses");
                });

            modelBuilder.Entity("Domain.Entities.WorkingSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModificationBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("WorkingDay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkingSchedules");
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WorkingSchedule", "WorkingSchedule")
                        .WithMany("Accounts")
                        .HasForeignKey("WorkingScheduleId");

                    b.Navigation("Role");

                    b.Navigation("WorkingSchedule");
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Domain.Entities.Koi", "Koi")
                        .WithMany("AppointmentLists")
                        .HasForeignKey("KoiId");

                    b.HasOne("Domain.Entities.CenterService", "Service")
                        .WithOne("Appointment")
                        .HasForeignKey("Domain.Entities.Appointment", "ServiceId");

                    b.Navigation("Koi");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Domain.Entities.CenterService", b =>
                {
                    b.HasOne("Domain.Entities.CenterTank", "Tank")
                        .WithMany("ServiceList")
                        .HasForeignKey("TankId");

                    b.HasOne("Domain.Entities.ServiceType", "ServiceType")
                        .WithMany("ListServices")
                        .HasForeignKey("TypeId");

                    b.Navigation("ServiceType");

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("Domain.Entities.Feedback", b =>
                {
                    b.HasOne("Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("Domain.Entities.Appointment", "FeedbackAppointment")
                        .WithOne("Feedback")
                        .HasForeignKey("Domain.Entities.Feedback", "AppointmentId");

                    b.Navigation("Account");

                    b.Navigation("FeedbackAppointment");
                });

            modelBuilder.Entity("Domain.Entities.Koi", b =>
                {
                    b.HasOne("Domain.Entities.Account", "Account")
                        .WithMany("KoiLists")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entities.MedicalPrescription", b =>
                {
                    b.HasOne("Domain.Entities.MedicalRecord", "MedicalRecordLink")
                        .WithOne("MedicalPrescription")
                        .HasForeignKey("Domain.Entities.MedicalPrescription", "MedicalRecordId");

                    b.Navigation("MedicalRecordLink");
                });

            modelBuilder.Entity("Domain.Entities.MedicalRecord", b =>
                {
                    b.HasOne("Domain.Entities.Appointment", "Appointment")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("Domain.Entities.MedicalRecord", "AppointmentId");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.HasOne("Domain.Entities.Appointment", "RatingAppointment")
                        .WithOne("Rating")
                        .HasForeignKey("Domain.Entities.Rating", "AppointmentId");

                    b.HasOne("Domain.Entities.Account", "Rater")
                        .WithMany()
                        .HasForeignKey("RaterId");

                    b.Navigation("Rater");

                    b.Navigation("RatingAppointment");
                });

            modelBuilder.Entity("Domain.Entities.ServiceType", b =>
                {
                    b.HasOne("Domain.Entities.TravelExpense", "TravelExpense")
                        .WithMany("ServiceTypeLists")
                        .HasForeignKey("TravelExpenseId");

                    b.Navigation("TravelExpense");
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Navigation("KoiLists");
                });

            modelBuilder.Entity("Domain.Entities.Appointment", b =>
                {
                    b.Navigation("Feedback")
                        .IsRequired();

                    b.Navigation("MedicalRecord")
                        .IsRequired();

                    b.Navigation("Rating")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CenterService", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CenterTank", b =>
                {
                    b.Navigation("ServiceList");
                });

            modelBuilder.Entity("Domain.Entities.Koi", b =>
                {
                    b.Navigation("AppointmentLists");
                });

            modelBuilder.Entity("Domain.Entities.MedicalRecord", b =>
                {
                    b.Navigation("MedicalPrescription")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Domain.Entities.ServiceType", b =>
                {
                    b.Navigation("ListServices");
                });

            modelBuilder.Entity("Domain.Entities.TravelExpense", b =>
                {
                    b.Navigation("ServiceTypeLists");
                });

            modelBuilder.Entity("Domain.Entities.WorkingSchedule", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
