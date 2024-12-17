-- Tạo dữ liệu cho bảng User
INSERT INTO User (username, password, full_name, email, phone_number, address, user_logs, avatar, role, created_at)
VALUES
('user1', 'password1', 'Nguyen Van A', 'user1@example.com', '0123456789', 'Hanoi', 'Log1', '/images/avatar1.png', 'admin', NOW()),
('user2', 'password2', 'Nguyen Thi B', 'user2@example.com', '0123456790', 'Ho Chi Minh', 'Log2', '/images/avatar2.png', 'customer', NOW());

-- Tạo dữ liệu cho bảng Customer
INSERT INTO Customer (user_id, full_name, phone_number, address)
VALUES
(1, 'Nguyen Van A', '0123456789', 'Hanoi'),
(2, 'Nguyen Thi B', '0123456790', 'Ho Chi Minh');

-- Tạo dữ liệu cho bảng Vehicle
INSERT INTO Vehicle (customer_id, vehicle_name, vehicle_model, vehicle_version, body_number, engine_number, vehicle_rate)
VALUES
(1, 'Toyota Camry', '2023', 'V5', 'ABC1234', 'ENG12345', 500000),
(2, 'Honda Civic', '2022', 'V4', 'DEF5678', 'ENG67890', 400000);

-- Tạo dữ liệu cho bảng InsurancePolicy
INSERT INTO InsurancePolicy (customer_id, vehicle_id, policy_number, policy_start_date, policy_end_date, policy_type, policy_amount, payment_status)
VALUES
(1, 1, 'POLICY123', '2023-01-01', '2024-01-01', 'Comprehensive', 1000000, 'Paid'),
(2, 2, 'POLICY456', '2023-06-01', '2024-06-01', 'Third Party', 500000, 'Pending');

-- Tạo dữ liệu cho bảng Claim
INSERT INTO Claim (policy_id, claim_number, accident_date, place_of_accident, insured_amount, claimable_amount, CreatedAt)
VALUES
(1, 'CLAIM123', '2023-08-15', 'Hanoi', 2000000, 1500000, NOW()),
(2, 'CLAIM456', '2023-07-25', 'Ho Chi Minh', 1000000, 500000, NOW());

-- Tạo dữ liệu cho bảng Comment
INSERT INTO Comment (customer_id, parent_comment_id, comment_text, rating, created_at, status)
VALUES
(1, NULL, 'Excellent service!', 5, NOW(), 'Active'),
(2, 1, 'I agree with the above comment!', 4, NOW(), 'Active');

-- Tạo dữ liệu cho bảng Contact
INSERT INTO Contact (customer_id, full_name, email, phone, subject, message, status)
VALUES
(1, 'Nguyen Van A', 'user1@example.com', '0123456789', 'Policy Inquiry', 'I have a question about my policy.', true),
(2, 'Nguyen Thi B', 'user2@example.com', '0123456790', 'Claim Status', 'What is the status of my claim?', false);

-- Tạo dữ liệu cho bảng CustomerSupportRequest
INSERT INTO CustomerSupportRequest (customer_id, support_type, support_description, support_payment, support_status, created_at)
VALUES
(1, 'Policy Change', 'Request to change policy coverage.', 'Paid', 'Open', NOW()),
(2, 'Claim Assistance', 'Need help with claim process.', 'Free', 'Pending', NOW());

-- Tạo dữ liệu cho bảng Estimate
INSERT INTO Estimate (customer_id, vehicle_id, policy_type, warranty, estimate_amount, created_at)
VALUES
(1, 1, 'Comprehensive', '2 Years', 1500000, NOW()),
(2, 2, 'Third Party', '1 Year', 500000, NOW());

-- Tạo dữ liệu cho bảng InsuranceHistory
INSERT INTO InsuranceHistory (policy_id, change_date, change_type, old_value, new_value, changed_by)
VALUES
(1, NOW(), 'Policy Update', 'Basic Coverage', 'Comprehensive Coverage', 1),
(2, NOW(), 'Payment Update', 'Unpaid', 'Paid', 2);

-- Tạo dữ liệu cho bảng Notification
INSERT INTO Notification (customer_id, message_type, message_content, sent_at, is_read)
VALUES
(1, 'Reminder', 'Your policy is about to expire.', NOW(), false),
(2, 'Alert', 'Your claim has been processed.', NOW(), true);

-- Tạo dữ liệu cho bảng Payment
INSERT INTO Payment (customer_id, policy_id, bill_number, payment_date, payment_amount, transaction_id, payment_status)
VALUES
(1, 1, 'BILL123', '2023-01-01', 1000000, 'TXN123', 'Paid'),
(2, 2, 'BILL456', '2023-06-01', 500000, 'TXN456', 'Pending');

-- Tạo dữ liệu cho bảng Report
INSERT INTO Report (report_type, generated_at, description)
VALUES
('Claim Report', NOW(), 'This is a report for all claims processed in the last month.'),
('Policy Report', NOW(), 'Report showing all active policies.');

-- Tạo dữ liệu cho bảng Services
INSERT INTO Services (policy_id, title, image, description, sort_order, status, startdate, enddate, CreatedAt, UpdatedAt)
VALUES
(1, 'Free Car Service', '/images/service1.jpg', 'Free service for car maintenance.', 1, true, '2023-01-01', '2024-01-01', NOW(), NULL),
(2, 'Roadside Assistance', '/images/service2.jpg', '24/7 roadside assistance service.', 2, true, '2023-06-01', '2024-06-01', NOW(), NULL);

-- Tạo dữ liệu cho bảng SpecialInsuranceRequest
INSERT INTO SpecialInsuranceRequest (customer_id, vehicle_id, request_type, request_description, request_date, status)
VALUES
(1, 1, 'Add Coverage', 'Request to add extra coverage for vehicle damage.', NOW(), 'Pending'),
(2, 2, 'Cancel Policy', 'Request to cancel the current policy.', NOW(), 'Approved');

-- Tạo dữ liệu cho bảng VehicleImage
INSERT INTO VehicleImage (vehicle_id, image_type, image_path, description, uploaded_at)
VALUES
(1, 'Vehicle', '/images/vehicle1.jpg', 'Image of Toyota Camry', NOW()),
(2, 'Insurance Document', '/images/document1.jpg', 'Insurance policy document for Honda Civic', NOW());
