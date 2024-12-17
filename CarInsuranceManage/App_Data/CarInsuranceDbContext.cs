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

        public DbSet<User> users { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<InsurancePolicy> insurance_policies { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Claim> claims { get; set; }
        public DbSet<CustomerSupportRequest> customer_support_requests { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Comment> comments { get; set; }
        public object CustomerSupportRequest { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    user_id = 1,
                    username = "admin",
                    password = "123", // Normally, you would hash the password
                    full_name = "Admin User",
                    email = "vunnth2307024@fpt.edu.vn",
                    phone_number = "0123456789",
                    address = "123 Admin Street",
                    user_logs = "Email",
                    avatar = "avatar.png",
                    role = "admin",
                    created_at = DateTime.Now
                },
                new User
                {
                    user_id = 2,
                    username = "john_doe",
                    password = "123",
                    full_name = "John Doe",
                    email = "vusena3107@gmail.com",
                    phone_number = "0987654321",
                    address = "123 Main St, Cityville",
                    user_logs = "Login logs",
                    avatar = "john_avatar.png",
                    role = "customer",
                    created_at = DateTime.Now
                }
            );

            // 2. Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customer_id = 1,
                    user_id = 1,
                    full_name = "Admin User",
                    phone_number = "0123456789",
                    address = "123 Admin Street"
                },
                new Customer
                {
                    customer_id = 2,
                    user_id = 2,
                    full_name = "John Doe",
                    phone_number = "0987654321",
                    address = "456 Main St, Cityville"
                }
            );

            // 3. Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    vehicle_id = 1,
                    customer_id = 2,
                    vehicle_name = "Toyota Camry",
                    vehicle_model = "2022",
                    vehicle_version = "SE",
                    body_number = "ABC123XYZ",
                    engine_number = "ENG123456789",
                    vehicle_rate = 25000.00M
                },
                new Vehicle
                {
                    vehicle_id = 2,
                    customer_id = 1,
                    vehicle_name = "Honda Accord",
                    vehicle_model = "2020",
                    vehicle_version = "LX",
                    body_number = "DEF456XYZ",
                    engine_number = "ENG987654321",
                    vehicle_rate = 22000.00M
                }
            );
            modelBuilder.Entity<InsurancePolicy>().HasData(
                    new InsurancePolicy
                    {
                        policy_id = 1,
                        customer_id = 2,
                        vehicle_id = 1,
                        policy_number = "POLICY12345",
                        policy_start_date = DateTime.Now,
                        policy_end_date = DateTime.Now.AddYears(1),
                        policy_type = "Comprehensive",
                        policy_amount = 50.00M,
                        payment_status = "Paid"  // Trạng thái thanh toán của hợp đồng
                    },
                    new InsurancePolicy
                    {
                        policy_id = 2,
                        customer_id = 1,
                        vehicle_id = 2,
                        policy_number = "POLICY67890",
                        policy_start_date = DateTime.Now,
                        policy_end_date = DateTime.Now.AddYears(1),
                        policy_type = "Third-Party",
                        policy_amount = 70.00M,
                        payment_status = "Unpaid"  // Trạng thái thanh toán của hợp đồng
                    },
                    new InsurancePolicy
                    {
                        policy_id = 3,
                        customer_id = 1,
                        vehicle_id = 2,
                        policy_number = "POLICY67890",
                        policy_start_date = DateTime.Now,
                        policy_end_date = DateTime.Now.AddYears(1),
                        policy_type = "Third-Party",
                        policy_amount = 90.00M,
                        payment_status = "Pending"  // Trạng thái thanh toán của hợp đồng
                    }
                );
            // 7. Seed Services
            modelBuilder.Entity<Services>().HasData(
                new Services
                {
                    id = 1,
                    policy_id = 1,
                    title = "Moto Insurance",
                    image = "moto.jpg",
                    description = "Full coverage for your vehicle.",
                    sort_order = 1,
                    status = true,
                    startdate = DateTime.Now,
                    enddate = DateTime.Now.AddMonths(12),
                    CreatedAt = DateTime.Now
                },
                new Services
                {
                    id = 2,
                    policy_id = 2,
                    title = "Car Insurance",
                    image = "car.jpg",
                    description = "Full coverage for your vehicle.",
                    sort_order = 1,
                    status = true,
                    startdate = DateTime.Now,
                    enddate = DateTime.Now.AddMonths(12),
                    CreatedAt = DateTime.Now
                },
                new Services
                {
                    id = 3,
                    policy_id = 3,
                    title = "Truck Insurance",
                    image = "truck.jpg",
                    description = "Basic third-party coverage for your vehicle.",
                    sort_order = 1,
                    status = true,
                    startdate = DateTime.Now,
                    enddate = DateTime.Now.AddMonths(12),
                    CreatedAt = DateTime.Now
                }
            );
            // 7. Seed Payments
            modelBuilder.Entity<Payment>().HasData(
                    new Payment
                    {
                        payment_id = 1,
                        customer_id = 2,
                        policy_id = 1,
                        bill_number = "BILL12345",
                        payment_date = DateTime.Now,
                        payment_amount = 1500.00M,
                        transaction_id = "TXN123456789",  // Mã giao dịch của thanh toán
                        payment_status = "SUCCESS"  // Trạng thái thanh toán
                    },
                    new Payment
                    {
                        payment_id = 2,
                        customer_id = 1,
                        policy_id = 2,
                        bill_number = "BILL67890",
                        payment_date = DateTime.Now,
                        payment_amount = 1000.00M,
                        transaction_id = "TXN987654321",  // Mã giao dịch của thanh toán
                        payment_status = "FAILED"  // Trạng thái thanh toán
                    }
                );

            // 8. Seed Claims
            modelBuilder.Entity<Claim>().HasData(
                new Claim
                {
                    claim_id = 1,
                    policy_id = 1,
                    claim_number = "CLAIM12345",
                    accident_date = DateTime.Now.AddMonths(-1),
                    place_of_accident = "Downtown",
                    insured_amount = 10000.00M,
                    claimable_amount = 8000.00M
                },
                new Claim
                {
                    claim_id = 2,
                    policy_id = 2,
                    claim_number = "CLAIM67890",
                    accident_date = DateTime.Now.AddMonths(-2),
                    place_of_accident = "Suburb",
                    insured_amount = 5000.00M,
                    claimable_amount = 4000.00M
                }
            );



            // 10. Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    comment_id = 1,
                    customer_id = 2,
                    parent_comment_id = null,
                    comment_text = "Great service! Highly recommend this insurance.",
                    rating = 5,
                    created_at = DateTime.Now,
                    status = "Active"
                },
                new Comment
                {
                    comment_id = 2,
                    customer_id = 1,
                    parent_comment_id = null,
                    comment_text = "Very affordable prices.",
                    rating = 4,
                    created_at = DateTime.Now,
                    status = "Active"
                }
            );

            

         
            // 15. Seed CustomerSupportRequests
            modelBuilder.Entity<CustomerSupportRequest>().HasData(
                new CustomerSupportRequest
                {
                    support_id = 1,
                    customer_id = 2,
                    support_type = "Billing",
                    support_description = "Need assistance with billing",
                    support_payment = "Paid",
                    support_status = "Open",
                    created_at = DateTime.Now
                }
            );

            // 16. Seed Notifications
            modelBuilder.Entity<Notification>().HasData(
                new Notification
                {
                    notification_id = 1,
                    customer_id = 2,
                    message_type = "Reminder",
                    message_content = "Your insurance policy is about to expire.",
                    sent_at = DateTime.Now,
                    is_read = false
                }
            );

            // 17. Seed Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    id = 1,
                    customer_id = 2,
                    full_name = "John Doe",
                    email = "john.doe@example.com",
                    phone = "0987654321",
                    subject = "Inquiry about policy renewal",
                    message = "I want to inquire about renewing my insurance policy.",
                    date_added = DateTime.Now,
                    date_modified = DateTime.Now,
                    status = true
                }
            );

        }
    }
}
