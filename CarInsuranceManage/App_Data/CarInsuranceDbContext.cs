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
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currentDate = new DateTime(2024, 1, 1); // Example constant date

            // Seed data for Users table
            modelBuilder.Entity<User>().HasData(
                new User { user_id = 1, username = "john_doe", password = "hashed_password1", full_name = "John Doe", email = "john.doe@example.com", phone_number = "1234567890", address = "123 Main St", user_logs = "Email", role = "Customer", created_at = currentDate },
                new User { user_id = 2, username = "jane_admin", password = "hashed_password2", full_name = "Jane Admin", email = "jane.admin@example.com", phone_number = "0987654321", address = "456 Elm St", user_logs = "Google",role = "Employee", created_at = currentDate }
            );

            // Seed data for Customers table
            modelBuilder.Entity<Customer>().HasData(
                new Customer { customer_id = 1, user_id = 1, full_name = "John Doe", phone_number = "1234567890", address = "123 Main St" }
            );

            // Seed data for Vehicles table
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { vehicle_id = 1, customer_id = 1, vehicle_name = "Toyota Corolla", vehicle_model = "2020", vehicle_version = "LE", body_number = "1234ABCD", engine_number = "ENG5678", vehicle_rate = 20000 }
            );

            // Seed data for VehicleImages table
            modelBuilder.Entity<VehicleImage>().HasData(
                new VehicleImage { image_id = 1, vehicle_id = 1, image_type = "Vehicle", image_path = "/images/vehicle1.jpg", description = "Front view of Toyota Corolla", uploaded_at = currentDate }
            );

            // Seed data for Estimates table
            modelBuilder.Entity<Estimate>().HasData(
                new Estimate { estimate_id = 1, customer_id = 1, vehicle_id = 1, policy_type = "Comprehensive", warranty = "1 Year", estimate_amount = 1500, created_at = currentDate }
            );

            // Seed data for InsurancePolicies table
            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy { policy_id = 1, customer_id = 1, vehicle_id = 1, policy_number = "POL123456", policy_start_date = currentDate, policy_end_date = currentDate.AddYears(1), policy_type = "Comprehensive", policy_amount = 1500 }
            );

            // Seed data for Payments table
            modelBuilder.Entity<Payment>().HasData(
                new Payment { payment_id = 1, customer_id = 1, policy_id = 1, bill_number = "BILL123", payment_date = currentDate, payment_amount = 1500 }
            );

            // Seed data for Claims table
            modelBuilder.Entity<Claim>().HasData(
                new Claim { claim_id = 1, policy_id = 1, claim_number = "CLAIM001", accident_date = currentDate, place_of_accident = "Highway 1", insured_amount = 1500, claimable_amount = 1400, CreatedAt = currentDate }
            );

            // Seed data for CompanyExpenses table
            modelBuilder.Entity<CompanyExpense>().HasData(
                new CompanyExpense { expense_id = 1, expense_type = "Marketing", expense_date = currentDate, expense_amount = 5000, created_at = currentDate }
            );

            // Seed data for Reports table
            modelBuilder.Entity<Report>().HasData(
                new Report { report_id = 1, report_type = "Annual Report", generated_at = currentDate, description = "Annual performance report" }
            );

            // Seed data for LoginLogs table
            modelBuilder.Entity<LoginLog>().HasData(
                new LoginLog { log_id = 1, user_id = 1, login_time = currentDate, ip_address = "192.168.1.1" }
            );

            // Seed data for InsuranceHistory table
            modelBuilder.Entity<InsuranceHistory>().HasData(
                new InsuranceHistory { history_id = 1, policy_id = 1, change_date = currentDate, change_type = "Policy Created", old_value = "", new_value = "Comprehensive Policy - $1500", changed_by = 1 }
            );

            // Seed data for SpecialInsuranceRequests table
            modelBuilder.Entity<SpecialInsuranceRequest>().HasData(
                new SpecialInsuranceRequest { request_id = 1, customer_id = 1, vehicle_id = 1, request_type = "Extended Coverage", request_description = "Extend policy coverage by 6 months", request_date = currentDate, status = "Pending" }
            );

            modelBuilder.Entity<CustomerSupportRequest>().HasData(
                 new CustomerSupportRequest
                 {
                     support_id = 1,
                     customer_id = 1, // Ensure this customer exists in Customers table
                     support_type = "Policy Inquiry",
                     support_description = "Question about policy details",
                     support_payment = "Paid",
                     support_status = "Open",
                     created_at = currentDate,
                     resolved_at = null, // NULL is fine for unresolved requests
                     resolved_by = 1 // Ensure this user exists in Users table
                 }
             );


            // Seed data for Notifications table
            modelBuilder.Entity<Notification>().HasData(
                new Notification { notification_id = 1, customer_id = 1, message_type = "Payment Reminder", message_content = "Your payment is due soon", sent_at = currentDate, is_read = false }
            );

            // Seed data for Contacts table
            modelBuilder.Entity<Contact>().HasData(
                new Contact { id = 1, customer_id = 1, full_name = "John Doe", email = "john.doe@example.com", phone = "1234567890", subject = "Policy Query", message = "What is covered under the policy?", date_added = currentDate, date_modified = currentDate, status = true }
            );

            // Seed data for BannerImages table
            modelBuilder.Entity<BannerImage>().HasData(
                new BannerImage { id = 1, image = "/images/banner1.jpg", link = "https://example.com", sort_order = 1, status = true }
            );

            // Seed data for Comments table
            modelBuilder.Entity<Comment>().HasData(
                new Comment { comment_id = 1, customer_id = 1, comment_text = "Excellent service!", rating = 5, created_at = currentDate, status = "Active" }
            );
        }


    }

}
