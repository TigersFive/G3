using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarInsuranceManage.Migrations
{
    /// <inheritdoc />
    public partial class carinsuranceDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "banners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    enddate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "company_expenses",
                columns: table => new
                {
                    expense_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    expense_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expense_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    expense_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_expenses", x => x.expense_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    report_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    report_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.report_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    full_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_logs = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "login_logs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    login_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ip_address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login_logs", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_login_logs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    parent_comment_id = table.Column<int>(type: "int", nullable: true),
                    comment_text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_comments_parent_comment_id",
                        column: x => x.parent_comment_id,
                        principalTable: "comments",
                        principalColumn: "comment_id");
                    table.ForeignKey(
                        name: "FK_comments_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subject = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_added = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contacts_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer_support_requests",
                columns: table => new
                {
                    support_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    support_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    support_description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    support_payment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    support_status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    resolved_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    resolved_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_support_requests", x => x.support_id);
                    table.ForeignKey(
                        name: "FK_customer_support_requests_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_support_requests_users_resolved_by",
                        column: x => x.resolved_by,
                        principalTable: "users",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    message_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message_content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sent_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_read = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_notifications_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vehicle_model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vehicle_version = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    body_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    engine_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vehicle_rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.vehicle_id);
                    table.ForeignKey(
                        name: "FK_vehicles_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estimates",
                columns: table => new
                {
                    estimate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    policy_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    warranty = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estimate_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estimates", x => x.estimate_id);
                    table.ForeignKey(
                        name: "FK_estimates_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estimates_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insurance_policies",
                columns: table => new
                {
                    policy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    policy_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    policy_start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    policy_end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    policy_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    policy_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_policies", x => x.policy_id);
                    table.ForeignKey(
                        name: "FK_insurance_policies_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurance_policies_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "special_insurance_requests",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    request_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    request_description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    request_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_special_insurance_requests", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_special_insurance_requests_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_special_insurance_requests_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicle_images",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    image_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_path = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uploaded_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_vehicle_images_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    claim_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    policy_id = table.Column<int>(type: "int", nullable: false),
                    claim_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    accident_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    place_of_accident = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    insured_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    claimable_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claims", x => x.claim_id);
                    table.ForeignKey(
                        name: "FK_claims_insurance_policies_policy_id",
                        column: x => x.policy_id,
                        principalTable: "insurance_policies",
                        principalColumn: "policy_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insurance_histories",
                columns: table => new
                {
                    history_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    policy_id = table.Column<int>(type: "int", nullable: false),
                    change_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    change_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    old_value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    new_value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    changed_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_histories", x => x.history_id);
                    table.ForeignKey(
                        name: "FK_insurance_histories_insurance_policies_policy_id",
                        column: x => x.policy_id,
                        principalTable: "insurance_policies",
                        principalColumn: "policy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurance_histories_users_changed_by",
                        column: x => x.changed_by,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    policy_id = table.Column<int>(type: "int", nullable: false),
                    bill_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    payment_amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_insurance_policies_policy_id",
                        column: x => x.policy_id,
                        principalTable: "insurance_policies",
                        principalColumn: "policy_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "banners",
                columns: new[] { "id", "CreatedAt", "UpdatedAt", "description", "enddate", "image", "link", "sort_order", "startdate", "status", "title" },
                values: new object[] { 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(454), null, "Get 20% off on all car insurance policies this summer.", new DateTime(2025, 2, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(462), "summer_sale_banner.jpg", "https://carinsurance.com/summer-sale", 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(458), true, "Summer Sale - 20% Off" });

            migrationBuilder.InsertData(
                table: "reports",
                columns: new[] { "report_id", "description", "generated_at", "report_type" },
                values: new object[] { 1, "Monthly revenue report for car insurance sales.", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(497), "Revenue Report" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address", "avatar", "created_at", "email", "full_name", "password", "phone_number", "role", "user_logs", "username" },
                values: new object[,]
                {
                    { 1, "123 Admin Street", "avatar.png", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(165), "vunnth2307024@fpt.edu.vn", "Admin User", "Vu@wk1162005", "0123456789", "admin", "Email", "admin" },
                    { 2, "123 Main St, Cityville", "john_avatar.png", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(168), "vusena3107@gmail.com", "John Doe", "Vu@wk1162005", "0987654321", "customer", "Login logs", "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "customer_id", "address", "full_name", "phone_number", "user_id" },
                values: new object[,]
                {
                    { 1, "123 Admin Street", "Admin User", "0123456789", 1 },
                    { 2, "456 Main St, Cityville", "John Doe", "0987654321", 2 }
                });

            migrationBuilder.InsertData(
                table: "login_logs",
                columns: new[] { "log_id", "ip_address", "login_time", "user_id" },
                values: new object[,]
                {
                    { 1, "192.168.1.1", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(511), 1 },
                    { 2, "192.168.1.2", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(512), 2 }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "comment_id", "comment_text", "created_at", "customer_id", "parent_comment_id", "rating", "status" },
                values: new object[,]
                {
                    { 1, "Great service! Highly recommend this insurance.", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(478), 2, null, 5, "Active" },
                    { 2, "Very affordable prices.", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(481), 1, null, 4, "Active" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "id", "customer_id", "date_added", "date_modified", "email", "full_name", "message", "phone", "status", "subject" },
                values: new object[] { 1, 2, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(601), new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(601), "john.doe@example.com", "John Doe", "I want to inquire about renewing my insurance policy.", "0987654321", true, "Inquiry about policy renewal" });

            migrationBuilder.InsertData(
                table: "customer_support_requests",
                columns: new[] { "support_id", "created_at", "customer_id", "resolved_at", "resolved_by", "support_description", "support_payment", "support_status", "support_type" },
                values: new object[] { 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(565), 2, null, null, "Need assistance with billing", "Paid", "Open", "Billing" });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "notification_id", "customer_id", "is_read", "message_content", "message_type", "sent_at" },
                values: new object[] { 1, 2, false, "Your insurance policy is about to expire.", "Reminder", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(579) });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "vehicle_id", "body_number", "customer_id", "engine_number", "vehicle_model", "vehicle_name", "vehicle_rate", "vehicle_version" },
                values: new object[,]
                {
                    { 1, "ABC123XYZ", 2, "ENG123456789", "2022", "Toyota Camry", 25000.00m, "SE" },
                    { 2, "DEF456XYZ", 1, "ENG987654321", "2020", "Honda Accord", 22000.00m, "LX" }
                });

            migrationBuilder.InsertData(
                table: "estimates",
                columns: new[] { "estimate_id", "created_at", "customer_id", "estimate_amount", "policy_type", "vehicle_id", "warranty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(359), 2, 1500.00m, "Comprehensive", 1, "3 years" },
                    { 2, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(361), 1, 1000.00m, "Third-Party", 2, "1 year" }
                });

            migrationBuilder.InsertData(
                table: "insurance_policies",
                columns: new[] { "policy_id", "customer_id", "policy_amount", "policy_end_date", "policy_number", "policy_start_date", "policy_type", "vehicle_id" },
                values: new object[,]
                {
                    { 1, 2, 1500.00m, new DateTime(2025, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(381), "POLICY12345", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(379), "Comprehensive", 1 },
                    { 2, 1, 1000.00m, new DateTime(2025, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(391), "POLICY67890", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(390), "Third-Party", 2 }
                });

            migrationBuilder.InsertData(
                table: "special_insurance_requests",
                columns: new[] { "request_id", "customer_id", "request_date", "request_description", "request_type", "status", "vehicle_id" },
                values: new object[] { 1, 2, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(549), "Requesting additional 2 years of warranty.", "Extended Warranty", "Pending", 1 });

            migrationBuilder.InsertData(
                table: "vehicle_images",
                columns: new[] { "image_id", "description", "image_path", "image_type", "uploaded_at", "vehicle_id" },
                values: new object[,]
                {
                    { 1, "Toyota Camry front view", "images/vehicle1.jpg", "Vehicle", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(335), 1 },
                    { 2, "Honda Accord side view", "images/vehicle2.jpg", "Vehicle", new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(338), 2 }
                });

            migrationBuilder.InsertData(
                table: "claims",
                columns: new[] { "claim_id", "CreatedAt", "accident_date", "claim_number", "claimable_amount", "insured_amount", "place_of_accident", "policy_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(426), new DateTime(2024, 11, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(429), "CLAIM12345", 8000.00m, 10000.00m, "Downtown", 1 },
                    { 2, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(433), new DateTime(2024, 10, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(434), "CLAIM67890", 4000.00m, 5000.00m, "Suburb", 2 }
                });

            migrationBuilder.InsertData(
                table: "insurance_histories",
                columns: new[] { "history_id", "change_date", "change_type", "changed_by", "new_value", "old_value", "policy_id" },
                values: new object[] { 1, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(531), "Updated", 1, "Policy Active", "Initial", 1 });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "payment_id", "bill_number", "customer_id", "payment_amount", "payment_date", "policy_id" },
                values: new object[,]
                {
                    { 1, "BILL12345", 2, 1500.00m, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(408), 1 },
                    { 2, "BILL67890", 1, 1000.00m, new DateTime(2024, 12, 15, 17, 28, 42, 96, DateTimeKind.Local).AddTicks(409), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_claims_policy_id",
                table: "claims",
                column: "policy_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_customer_id",
                table: "comments",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_parent_comment_id",
                table: "comments",
                column: "parent_comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_customer_id",
                table: "contacts",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_support_requests_customer_id",
                table: "customer_support_requests",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_support_requests_resolved_by",
                table: "customer_support_requests",
                column: "resolved_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_user_id",
                table: "customers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_estimates_customer_id",
                table: "estimates",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_estimates_vehicle_id",
                table: "estimates",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_histories_changed_by",
                table: "insurance_histories",
                column: "changed_by");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_histories_policy_id",
                table: "insurance_histories",
                column: "policy_id");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_policies_customer_id",
                table: "insurance_policies",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_insurance_policies_vehicle_id",
                table: "insurance_policies",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_login_logs_user_id",
                table: "login_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_customer_id",
                table: "notifications",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_customer_id",
                table: "payments",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_policy_id",
                table: "payments",
                column: "policy_id");

            migrationBuilder.CreateIndex(
                name: "IX_special_insurance_requests_customer_id",
                table: "special_insurance_requests",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_special_insurance_requests_vehicle_id",
                table: "special_insurance_requests",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_images_vehicle_id",
                table: "vehicle_images",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_customer_id",
                table: "vehicles",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "company_expenses");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "customer_support_requests");

            migrationBuilder.DropTable(
                name: "estimates");

            migrationBuilder.DropTable(
                name: "insurance_histories");

            migrationBuilder.DropTable(
                name: "login_logs");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "special_insurance_requests");

            migrationBuilder.DropTable(
                name: "vehicle_images");

            migrationBuilder.DropTable(
                name: "insurance_policies");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
