-- 1. Banner Table
CREATE TABLE Banners (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    image VARCHAR(255) NOT NULL,
    Description VARCHAR(500) NOT NULL,
    link VARCHAR(255) NOT NULL,
    sort_order INT CHECK (sort_order >= 0 AND sort_order <= 1000),
    status TINYINT(1) NOT NULL,
    StartDate DATETIME NULL,
    EndDate DATETIME NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NULL
);

-- 2. Claim Table
CREATE TABLE Claims (
    claim_id INT AUTO_INCREMENT PRIMARY KEY,
    policy_id INT NOT NULL,
    claim_number VARCHAR(50) NOT NULL,
    accident_date DATETIME NOT NULL,
    place_of_accident VARCHAR(255) NULL,
    insured_amount DECIMAL(18, 2) NOT NULL,
    claimable_amount DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicies(policy_id)
);

-- 3. Comment Table
CREATE TABLE Comments (
    comment_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    parent_comment_id INT NULL,
    comment_text TEXT NOT NULL,
    rating INT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) NOT NULL,  -- 'Active' or 'Archived'
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (parent_comment_id) REFERENCES Comments(comment_id)
);

-- 5. Contact Table
CREATE TABLE Contacts (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    full_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    subject VARCHAR(255) NOT NULL,
    message TEXT NOT NULL,
    date_added DATETIME DEFAULT CURRENT_TIMESTAMP,
    date_modified DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    status TINYINT(1) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

-- 6. Customer Table
CREATE TABLE Customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    address VARCHAR(255) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- 7. CustomerSupportRequest Table
CREATE TABLE CustomerSupportRequests (
    support_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    support_type VARCHAR(100) NOT NULL,
    support_description TEXT NOT NULL,
    support_payment VARCHAR(100) NOT NULL,
    support_status VARCHAR(50) NOT NULL,  -- 'Open', 'Closed', 'Pending'
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    resolved_at DATETIME NULL,
    resolved_by INT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (resolved_by) REFERENCES Users(user_id)
);

-- 8. Estimate Table
CREATE TABLE Estimates (
    estimate_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    vehicle_id INT NOT NULL,
    policy_type VARCHAR(50) NOT NULL,
    warranty VARCHAR(50) NOT NULL,
    estimate_amount DECIMAL(18, 2) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES Vehicles(vehicle_id)
);

-- 9. InsuranceHistory Table
CREATE TABLE InsuranceHistories (
    history_id INT AUTO_INCREMENT PRIMARY KEY,
    policy_id INT NOT NULL,
    change_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    change_type VARCHAR(50) NOT NULL,
    old_value TEXT NOT NULL,
    new_value TEXT NOT NULL,
    changed_by INT NOT NULL,
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicies(policy_id),
    FOREIGN KEY (changed_by) REFERENCES Users(user_id)
);

-- 10. InsurancePolicy Table
CREATE TABLE InsurancePolicies (
    policy_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    vehicle_id INT NOT NULL,
    policy_number VARCHAR(50) NOT NULL,
    policy_start_date DATETIME NOT NULL,
    policy_end_date DATETIME NOT NULL,
    policy_type VARCHAR(50) NOT NULL,
    policy_amount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES Vehicles(vehicle_id)
);

-- 11. LoginLog Table
CREATE TABLE LoginLogs (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    login_time DATETIME DEFAULT CURRENT_TIMESTAMP,
    ip_address VARCHAR(50) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- 12. Notification Table
CREATE TABLE Notifications (
    notification_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    message_type VARCHAR(100) NOT NULL,
    message_content TEXT NOT NULL,
    sent_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_read TINYINT(1) DEFAULT 0,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

-- 13. Payment Table
CREATE TABLE Payments (
    payment_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    policy_id INT NOT NULL,
    bill_number VARCHAR(50) NOT NULL,
    payment_date DATETIME NOT NULL,
    payment_amount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicies(policy_id)
);

-- 14. Report Table
CREATE TABLE Reports (
    report_id INT AUTO_INCREMENT PRIMARY KEY,
    report_type VARCHAR(50) NOT NULL,
    generated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    description TEXT NULL
);

-- 15. SpecialInsuranceRequest Table
CREATE TABLE SpecialInsuranceRequests (
    request_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    vehicle_id INT NOT NULL,
    request_type VARCHAR(100) NOT NULL,
    request_description TEXT NOT NULL,
    request_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) NOT NULL,  -- 'Pending', 'Approved', 'Denied'
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES Vehicles(vehicle_id)
);

-- 16. User Table
CREATE TABLE Users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) NULL,
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15) NULL,
    address VARCHAR(255) NULL,
    user_logs TEXT NOT NULL,
    avatar VARCHAR(255) NULL,  -- Avatar field
    role VARCHAR(50) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 17. Vehicle Table
CREATE TABLE Vehicles (
    vehicle_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    vehicle_name VARCHAR(100) NOT NULL,
    vehicle_model VARCHAR(100) NOT NULL,
    vehicle_version VARCHAR(100) NOT NULL,
    body_number VARCHAR(50) NOT NULL,
    engine_number VARCHAR(50) NOT NULL,
    vehicle_rate DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

-- 18. VehicleImage Table
CREATE TABLE VehicleImages (
    image_id INT AUTO_INCREMENT PRIMARY KEY,
    vehicle_id INT NOT NULL,
    image_type VARCHAR(50) NOT NULL,  -- 'Vehicle', 'Insurance Document', 'Claim Document'
    image_path VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    uploaded_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (vehicle_id) REFERENCES Vehicles(vehicle_id)
);
