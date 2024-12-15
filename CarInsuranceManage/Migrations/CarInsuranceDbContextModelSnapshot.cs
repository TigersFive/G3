﻿// <auto-generated />
using System;
using CarInsuranceManage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInsuranceManage.Migrations
{
    [DbContext(typeof(CarInsuranceDbContext))]
    partial class CarInsuranceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CarInsuranceManage.Models.BannerImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("sort_order")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("BannerImages");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Claim", b =>
                {
                    b.Property<int>("claim_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("claim_id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("accident_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("claim_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("claimable_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("insured_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("place_of_accident")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("policy_id")
                        .HasColumnType("int");

                    b.HasKey("claim_id");

                    b.HasIndex("policy_id");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Comment", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("comment_id"));

                    b.Property<string>("comment_text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<int?>("parent_comment_id")
                        .HasColumnType("int");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("comment_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("parent_comment_id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.CompanyExpense", b =>
                {
                    b.Property<int>("expense_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("expense_id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("expense_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("expense_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("expense_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("expense_id");

                    b.ToTable("CompanyExpenses");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_added")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date_modified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.HasIndex("customer_id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("customer_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("customer_id");

                    b.HasIndex("user_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.CustomerSupportRequest", b =>
                {
                    b.Property<int>("support_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("support_id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("resolved_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("resolved_by")
                        .HasColumnType("int");

                    b.Property<string>("support_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("support_payment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("support_status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("support_type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("support_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("resolved_by");

                    b.ToTable("CustomerSupportRequests");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Estimate", b =>
                {
                    b.Property<int>("estimate_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("estimate_id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<decimal>("estimate_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("policy_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("vehicle_id")
                        .HasColumnType("int");

                    b.Property<string>("warranty")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("estimate_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("Estimates");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.InsuranceHistory", b =>
                {
                    b.Property<int>("history_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("history_id"));

                    b.Property<DateTime>("change_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("change_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("changed_by")
                        .HasColumnType("int");

                    b.Property<string>("new_value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("old_value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("policy_id")
                        .HasColumnType("int");

                    b.HasKey("history_id");

                    b.HasIndex("changed_by");

                    b.HasIndex("policy_id");

                    b.ToTable("InsuranceHistories");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.InsurancePolicy", b =>
                {
                    b.Property<int>("policy_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("policy_id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<decimal>("policy_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("policy_end_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("policy_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("policy_start_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("policy_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("vehicle_id")
                        .HasColumnType("int");

                    b.HasKey("policy_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("InsurancePolicies");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.LoginLog", b =>
                {
                    b.Property<int>("log_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("log_id"));

                    b.Property<string>("ip_address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("login_time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("log_id");

                    b.HasIndex("user_id");

                    b.ToTable("LoginLogs");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Notification", b =>
                {
                    b.Property<int>("notification_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("notification_id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<bool>("is_read")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("message_content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("message_type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("sent_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("notification_id");

                    b.HasIndex("customer_id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Payment", b =>
                {
                    b.Property<int>("payment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("payment_id"));

                    b.Property<string>("bill_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<decimal>("payment_amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("payment_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("policy_id")
                        .HasColumnType("int");

                    b.HasKey("payment_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("policy_id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Report", b =>
                {
                    b.Property<int>("report_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("report_id"));

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("generated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("report_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("report_id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.SpecialInsuranceRequest", b =>
                {
                    b.Property<int>("request_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("request_id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("request_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("request_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("request_type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("vehicle_id")
                        .HasColumnType("int");

                    b.HasKey("request_id");

                    b.HasIndex("customer_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("SpecialInsuranceRequests");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("user_id"));

                    b.Property<string>("address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("full_name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("phone_number")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("user_logs")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Vehicle", b =>
                {
                    b.Property<int>("vehicle_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("vehicle_id"));

                    b.Property<string>("body_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("engine_number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("vehicle_model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("vehicle_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("vehicle_rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("vehicle_version")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("vehicle_id");

                    b.HasIndex("customer_id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.VehicleImage", b =>
                {
                    b.Property<int>("image_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("image_id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image_path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("image_type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("uploaded_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("vehicle_id")
                        .HasColumnType("int");

                    b.HasKey("image_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("VehicleImages");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Claim", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.InsurancePolicy", "InsurancePolicy")
                        .WithMany()
                        .HasForeignKey("policy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsurancePolicy");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Comment", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.Comment", "ParentComment")
                        .WithMany("Replies")
                        .HasForeignKey("parent_comment_id");

                    b.Navigation("Customer");

                    b.Navigation("ParentComment");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Contact", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Customer", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.CustomerSupportRequest", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("resolved_by");

                    b.Navigation("Customer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Estimate", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.InsuranceHistory", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("changed_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.InsurancePolicy", "InsurancePolicy")
                        .WithMany()
                        .HasForeignKey("policy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsurancePolicy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.InsurancePolicy", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.LoginLog", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Notification", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Payment", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.InsurancePolicy", "InsurancePolicy")
                        .WithMany()
                        .HasForeignKey("policy_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InsurancePolicy");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.SpecialInsuranceRequest", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsuranceManage.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Vehicle", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.VehicleImage", b =>
                {
                    b.HasOne("CarInsuranceManage.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarInsuranceManage.Models.Comment", b =>
                {
                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
