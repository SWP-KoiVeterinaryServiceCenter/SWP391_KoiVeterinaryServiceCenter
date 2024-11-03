using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CenterTank> CenterTanks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Koi> Kois { get; set; }
        public DbSet<MedicalPrescription> MedicalPrescriptions { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CenterService> CenterServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<TravelExpense> TravelExpenses { get; set; }
        public DbSet<WorkingSchedule> WorkingSchedules { get; set; }
        public DbSet<AccountSchedule> AccountSchedules { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
