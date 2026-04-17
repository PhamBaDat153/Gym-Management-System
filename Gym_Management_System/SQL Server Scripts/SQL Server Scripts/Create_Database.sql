

USE db48275;
GO

-- 2. Drop Tables (in order of dependency)
-- We drop junction/child tables first
DROP TABLE IF EXISTS [Receipt];
DROP TABLE IF EXISTS [Schedule];
DROP TABLE IF EXISTS [EmployeeRole];
DROP TABLE IF EXISTS [Employee];
DROP TABLE IF EXISTS [Member];
DROP TABLE IF EXISTS [Package];
DROP TABLE IF EXISTS [PaymentMethod];
DROP TABLE IF EXISTS [SessionStatus];
DROP TABLE IF EXISTS [EmployeeStatus];
DROP TABLE IF EXISTS [Role];
DROP TABLE IF EXISTS [MemberReport];
DROP TABLE IF EXISTS [RevenueReport];
GO

-- 3. Create Lookup/Independent Tables
CREATE TABLE [Role] (
        role_id INT PRIMARY KEY, 
        role_name VARCHAR(255) NOT NULL -- Receptionist, Manager, Admin, Trainer
);

CREATE TABLE [SessionStatus] (
    status_id INT PRIMARY KEY,
    status NVARCHAR(50) NOT NULL -- Chưa diễn ra, Đang diễn ra, Đã hoàn thành
);

CREATE TABLE [PaymentMethod] (
    method_id INT PRIMARY KEY,
    method_name NVARCHAR(255) NOT NULL -- Tiền mặt, Quẹt thẻ, Chuyển khoản
);

-- 4. Create Main Entity Tables
Create TABLE [Package] (
    package_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    package_name NVARCHAR(255) NOT NULL,
    duration INT NOT NULL,
    price INT NOT NULL,
    with_trainer BIT NOT NULL,
    is_active BIT NOT NULL
);

CREATE TABLE [Member] (
    member_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    member_name NVARCHAR(255) NOT NULL,
    gender BIT NOT NULL,
    date_of_birth DATE NOT NULL,
    age INT NOT NULL,
    phone_number VARCHAR(11) NOT NULL,
    email VARCHAR(255) NOT NULL,
    remaining_duration INT NOT NULL,
    register_date DATE NOT NULL,
    has_trainer BIT NOT NULL,
    is_expired BIT NOT NULL,
    is_active BIT NOT NULL
);

CREATE TABLE [Employee] (
    employee_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    login_key VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    image_url VARCHAR(255) NULL,
    employee_name NVARCHAR(255) NOT NULL,
    phone_number VARCHAR(11) NOT NULL,
    date_of_birth DATE NOT NULL,
    salary INT NOT NULL,
    hire_date DATE NOT NULL,
    status BIT NOT NULL,
    is_active BIT NOT NULL,
);

-- 5. Create Junction/Relationship Tables
CREATE TABLE [EmployeeRole] (
    employee_id UNIQUEIDENTIFIER NOT NULL,
    role_id INT NOT NULL,
    PRIMARY KEY (employee_id, role_id),
    CONSTRAINT FK_EmpRole_Employee FOREIGN KEY (employee_id) REFERENCES [Employee](employee_id),
    CONSTRAINT FK_EmpRole_Role FOREIGN KEY (role_id) REFERENCES [Role](role_id)
);

CREATE TABLE [Schedule] (
    schedule_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    employee_id UNIQUEIDENTIFIER NOT NULL,
    member_id UNIQUEIDENTIFIER NOT NULL,
    note NVARCHAR(255),
    schedule_date DATE NOT NULL,
    session_start DATETIME NOT NULL,
    session_end DATETIME NOT NULL,
    session_status INT NOT NULL,
    CONSTRAINT FK_Schedule_Employee FOREIGN KEY (employee_id) REFERENCES [Employee](employee_id),
    CONSTRAINT FK_Schedule_Member FOREIGN KEY (member_id) REFERENCES [Member](member_id),
    CONSTRAINT FK_Schedule_Status FOREIGN KEY (session_status) REFERENCES [SessionStatus](status_id)
);

CREATE TABLE [Receipt] (
    receipt_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    member_id UNIQUEIDENTIFIER NOT NULL,
    package_id UNIQUEIDENTIFIER NOT NULL,
    total_amount INT NOT NULL,
    payment_date DATE NOT NULL,
    payment_method INT NOT NULL,
    CONSTRAINT FK_Receipt_Member FOREIGN KEY (member_id) REFERENCES [Member](member_id),
    CONSTRAINT FK_Receipt_Package FOREIGN KEY (package_id) REFERENCES [Package](package_id),
    CONSTRAINT FK_Receipt_Method FOREIGN KEY (payment_method) REFERENCES [PaymentMethod](method_id)
);

-- 6. Create Reporting Tables
CREATE TABLE [MemberReport] (
    report_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    total_member INT NOT NULL,
    monthly_new_member INT NOT NULL,
    monthly_loss_member INT NOT NULL,
    average_age INT NOT NULL,
    common_gender BIT NOT NULL,
    report_date DATE NOT NULL
);

CREATE TABLE [RevenueReport] (
    report_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    best_sell_package NVARCHAR(255) NOT NULL,
    least_sell_package NVARCHAR(255) NOT NULL,
    total_package_sold INT NOT NULL,
    total_amount INT NOT NULL,
    total_cost INT NOT NULL,
    net_profit INT NOT NULL,
    report_date DATE NOT NULL
);
GO

INSERT INTO dbo.PaymentMethod (method_id, method_name) VALUES (1, N'Tiền mặt'), (2, N'Quẹt thẻ'), (3, N'Chuyển khoản');