using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<EmployeeDependent> EmployeeDependent { get; set; }
        public DbSet<AllowanceType> AllowanceType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<GeneralRequest> GeneralRequest { get; set; }
        public DbSet<GeneralRequestType> GeneralRequestType { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankBranch> BankBranch { get; set; }
        public DbSet<ShiftType> ShiftType { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<JobDescription> JobDescription { get; set; }
        public DbSet<TimeAttendance> TimeAttendance { get; set; }
        public DbSet<TimeAttendanceStatus> TimeAttendanceStatus { get; set; }
        public DbSet<EmployeeShift> EmployeeShift { get; set; }
        public DbSet<EmployeeShiftToEmployee> EmployeeShiftToEmployee { get; set; }
        public DbSet<ShiftTypeEmployeeShift> ShiftTypeEmployeeShift { get; set; }
        public DbSet<SalaryInfo> SalaryInfo { get; set; }
        public DbSet<Grade> Grade { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=154.12.237.206;Initial Catalog=K2SelfService;User ID=zuhairi;Password=_N3W_Y0r(K);TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranch>(entity =>
            {
                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankBranch)
                    .HasForeignKey(d => d.BankID)
                    .HasConstraintName("fk_bank-bankbranch");
            });
             modelBuilder.Entity<EmployeeDependent>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDependent)
                    .HasForeignKey(d => d.EmployeeID)
                    .HasConstraintName("fk_Employee-EmployeeDependent");
                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.EmployeeDependent)
                    .HasForeignKey(d => d.RelationshipID)
                    .HasConstraintName("fk_Relationship-EmployeeDependent");
            });
             modelBuilder.Entity<TimeAttendance>(entity =>
            {
                entity.HasOne(d => d.TimeAttendanceStatus)
                      .WithMany(p => p.TimeAttendance)
                      .HasForeignKey(d => d.TimeAttendanceStatusID)
                      .HasConstraintName("fk_TimeAttendance-TimeAttendanceStatus");
                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.TimeAttendance)
                      .HasForeignKey(d =>d.EmployeeID)
                      .HasConstraintName("fk_Employee-TimeAttendance");
            });
             modelBuilder.Entity<SalaryInfo>(entity =>
            {
               
                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.SalaryInfo)
                      .HasForeignKey(d =>d.EmployeeID)
                      .HasConstraintName("fk_SalaryInfo-Employee");
                entity.HasOne(d => d.BankBranch)
                      .WithMany(p => p.SalaryInfo)
                      .HasForeignKey(d =>d.BankBranchID)
                      .HasConstraintName("fk_SalaryInfo-Bankbranch");
            });
             modelBuilder.Entity<GeneralRequest>(entity =>
            {
                entity.HasOne(d => d.GeneralRequestType)
                      .WithMany(p => p.GeneralRequest)
                      .HasForeignKey(d => d.GeneralRequestTypeID)
                      .HasConstraintName("fk_GeneralRequest-GeneralRequestType");
                entity.HasOne(d => d.Employee)
                      .WithMany(p => p.GeneralRequest)
                      .HasForeignKey(d =>d.EmployeeID)
                      .HasConstraintName("fk_GeneralRequest-Employee");
            });
            modelBuilder.Entity<EmployeeShift>(entity =>
           {
               entity.HasMany(d => d.Employee)
                     .WithMany(p => p.EmployeeShift)
                     .UsingEntity<EmployeeShiftToEmployee>(
                       l => l.HasOne<Employee>(e => e.Employee).WithMany(e => e.EmployeeShiftToEmployee).HasForeignKey(e => e.EmployeeId),
                       r => r.HasOne<EmployeeShift>(e => e.EmployeeShift).WithMany(e => e.EmployeeShiftToEmployee).HasForeignKey(e => e.EmployeeShiftId));

               entity.HasMany(d => d.ShiftType)
                    .WithMany(p => p.EmployeeShifts)
                    .UsingEntity<ShiftTypeEmployeeShift>(
                       l => l.HasOne<ShiftType>(e => e.ShiftType).WithMany(e => e.ShiftTypeEmployeeShift).HasForeignKey(e => e.ShiftTypeId),
                       r => r.HasOne<EmployeeShift>(e=> e.EmployeeShift).WithMany(e=>e.ShiftTypeEmployeeShift).HasForeignKey(e=>e.EmployeeShiftId));
               
           });
             modelBuilder.Entity<Employee>(entity =>
           {
               entity.HasOne(d => d.Gender)
                     .WithMany(p => p.Emplooye)
                     .HasForeignKey(d =>d.GenderID)
                     .HasConstraintName("fk_Employee-Gender");
               entity.HasOne(d => d.JobDescription)
                     .WithMany(p => p.Employee)
                     .HasForeignKey(d =>d.JobDescriptionID)
                     .HasConstraintName("fk_Employee-JobDescription");
               entity.HasOne(d => d.MaritalStatus)
                     .WithMany(p => p.Employee)
                     .HasForeignKey(d =>d.MaritalStatusID)
                     .HasConstraintName("fk_Employee-MaritalStatus");
               entity.HasOne(d => d.Nationality)
                     .WithMany(p => p.Employee)
                     .HasForeignKey(d =>d.NationalityID)
                     .HasConstraintName("fk_Employee-Nationality");
               entity.HasOne(d => d.Country)
                     .WithMany(p => p.Employee)
                     .HasForeignKey(d =>d.CountryID)
                     .HasConstraintName("fk_Employee-Country");
               entity.HasOne(d => d.Grade)
                     .WithMany(p => p.Employee)
                     .HasForeignKey(d =>d.GradeID)
                     .HasConstraintName("fk_Employee-Grade");
              
           });

     

        }
    }
}
