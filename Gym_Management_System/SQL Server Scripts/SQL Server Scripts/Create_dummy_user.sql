USE GymManagementSystem;
GO

-----------------------------------------------------------
-- 0. RESET TABLES (Cleanup existing data)
-----------------------------------------------------------
-- Delete from Junction table first to avoid FK conflicts
DELETE FROM [EmployeeRole];
-- Delete from main tables
DELETE FROM [Employee];
DELETE FROM [Role];
DELETE FROM [EmployeeStatus];
GO

-----------------------------------------------------------
-- 1. INSERT ROLES
-----------------------------------------------------------
INSERT INTO [Role] (role_id, role_name) VALUES 
(1, 'Admin'), 
(2, 'Manager'), 
(3, 'Receptionist'), 
(4, 'Trainer');

-----------------------------------------------------------
-- 2. INSERT EMPLOYEE STATUS
-----------------------------------------------------------
INSERT INTO [EmployeeStatus] (status_id, status) VALUES 
(1, N'Hoạt động');

-----------------------------------------------------------
-- 3. DECLARE IDs FOR LINKING
-----------------------------------------------------------
DECLARE @AdminID UNIQUEIDENTIFIER = NEWID();
DECLARE @ManagerID UNIQUEIDENTIFIER = NEWID();
DECLARE @ReceptionistID UNIQUEIDENTIFIER = NEWID();
DECLARE @TrainerID UNIQUEIDENTIFIER = NEWID();

-----------------------------------------------------------
-- 4. INSERT EMPLOYEES (Password: lol123)
-----------------------------------------------------------
INSERT INTO [Employee] (employee_id, login_key, password, email, employee_name, phone_number, date_of_birth, salary, hire_date, status, is_active)
VALUES 
(@AdminID, 'admin', 'lol123', 'admin@gym.com', N'Nguyễn Admin', '0900000001', '1990-01-01', 25000000, GETDATE(), 1, 1),
(@ManagerID, 'manager', 'lol123', 'manager@gym.com', N'Trần Manager', '0900000002', '1992-05-15', 20000000, GETDATE(), 1, 1),
(@ReceptionistID, 'receptionist', 'lol123', 'reception@gym.com', N'Lê Tiếp Tân', '0900000003', '1998-10-20', 10000000, GETDATE(), 1, 1),
(@TrainerID, 'trainer', 'lol123', 'trainer@gym.com', N'Phạm Huấn Luyện Viên', '0900000004', '1995-03-12', 15000000, GETDATE(), 1, 1);

-----------------------------------------------------------
-- 5. MAP EMPLOYEES TO ROLES (Hierarchical Assignment)
-----------------------------------------------------------

-- ADMIN: All roles (1, 2, 3, 4)
INSERT INTO [EmployeeRole] (employee_id, role_id) VALUES 
(@AdminID, 1), (@AdminID, 2), (@AdminID, 3), (@AdminID, 4);