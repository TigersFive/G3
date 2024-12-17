CREATE TABLE insurance_policies (
    policy_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    vehicle_id INT,
    policy_number VARCHAR(50) NOT NULL,
    policy_start_date DATETIME,
    policy_end_date DATETIME,
    policy_type VARCHAR(50) NOT NULL,
    policy_amount DECIMAL(18, 2),
    payment_status VARCHAR(50) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES vehicles(vehicle_id)
);

CREATE TABLE claims (
    claim_id INT AUTO_INCREMENT PRIMARY KEY,
    policy_id INT,
    claim_number VARCHAR(50),
    accident_date DATETIME,
    place_of_accident VARCHAR(255),
    insured_amount DECIMAL(18, 2),
    claimable_amount DECIMAL(18, 2),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicy(policy_id)
);

CREATE TABLE comments (
    comment_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    parent_comment_id INT,
    comment_text TEXT NOT NULL,
    rating INT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) NOT NULL,  -- 'Active' or 'Archived'
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (parent_comment_id) REFERENCES Comment(comment_id)
);

CREATE TABLE contacts (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    full_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    subject VARCHAR(255) NOT NULL,
    message TEXT NOT NULL,
    date_added DATETIME DEFAULT CURRENT_TIMESTAMP,
    date_modified DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    status BOOLEAN NOT NULL,  -- Active or Inactive
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    full_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    address VARCHAR(255) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE customer_support_requests (
    support_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    support_type VARCHAR(100) NOT NULL,
    support_description TEXT NOT NULL,
    support_payment VARCHAR(50) NOT NULL,
    support_status VARCHAR(50) NOT NULL,  -- 'Open', 'Closed', 'Pending'
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    resolved_at DATETIME,
    resolved_by INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (resolved_by) REFERENCES User(user_id)
);

CREATE TABLE estimates (
    estimate_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    vehicle_id INT,
    policy_type VARCHAR(50) NOT NULL,
    warranty VARCHAR(50) NOT NULL,
    estimate_amount DECIMAL(18, 2),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES vehicles(vehicle_id)
);

CREATE TABLE insurance_histories (
    history_id INT AUTO_INCREMENT PRIMARY KEY,
    policy_id INT,
    change_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    change_type VARCHAR(50) NOT NULL,
    old_value TEXT NOT NULL,
    new_value TEXT NOT NULL,
    changed_by INT,
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicy(policy_id),
    FOREIGN KEY (changed_by) REFERENCES User(user_id)
);

CREATE TABLE notifications (
    notification_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    message_type VARCHAR(100) NOT NULL,
    message_content TEXT NOT NULL,
    sent_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_read BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE payments (
    payment_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    policy_id INT,
    bill_number VARCHAR(50) NOT NULL,
    payment_date DATETIME NOT NULL,
    payment_amount DECIMAL(18, 2) NOT NULL,
    transaction_id VARCHAR(100),
    payment_status VARCHAR(50) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicy(policy_id)
);

CREATE TABLE reports (
    report_id INT AUTO_INCREMENT PRIMARY KEY,
    report_type VARCHAR(50) NOT NULL,
    generated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    description TEXT
);

CREATE TABLE services (
    id INT AUTO_INCREMENT PRIMARY KEY,
    policy_id INT,
    title VARCHAR(255) NOT NULL,
    image VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    sort_order INT NOT NULL,
    status BOOLEAN NOT NULL,
    startdate DATETIME,
    enddate DATETIME,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (policy_id) REFERENCES InsurancePolicy(policy_id)
);

CREATE TABLE special_insurance_requests (
    request_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    vehicle_id INT,
    request_type VARCHAR(100) NOT NULL,
    request_description TEXT NOT NULL,
    request_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) NOT NULL,  -- 'Pending', 'Approved', 'Denied'
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (vehicle_id) REFERENCES vehicles(vehicle_id)
);

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(100),
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15),
    address VARCHAR(255),
    user_logs TEXT NOT NULL,
    avatar VARCHAR(255),
    role VARCHAR(50) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE vehicles (
    vehicle_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT,
    vehicle_name VARCHAR(100) NOT NULL,
    vehicle_model VARCHAR(100) NOT NULL,
    vehicle_version VARCHAR(100) NOT NULL,
    body_number VARCHAR(50) NOT NULL,
    engine_number VARCHAR(50) NOT NULL,
    vehicle_rate DECIMAL(18, 2),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE vehicle_images (
    image_id INT AUTO_INCREMENT PRIMARY KEY,
    vehicle_id INT,
    image_type VARCHAR(50) NOT NULL,  -- 'vehicles', 'Insurance Document', 'Claim Document'
    image_path VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    uploaded_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (vehicle_id) REFERENCES vehicles(vehicle_id)
);
