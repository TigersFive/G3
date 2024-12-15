using CarInsuranceManage.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarInsuranceManage.Database
{

    public class CarInsuranceDbContext : DbContext
    {
        public CarInsuranceDbContext(DbContextOptions<CarInsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<CompanyExpense> CompanyExpenses { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<InsuranceHistory> InsuranceHistories { get; set; }
        public DbSet<SpecialInsuranceRequest> SpecialInsuranceRequests { get; set; }
        public DbSet<CustomerSupportRequest> CustomerSupportRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // Ensure you are using the default SaveChangesAsync
        // There's no need to implement SaveChangesAsync unless you need to customize it
    }

}
