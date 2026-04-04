USE GymManagementSystem;
GO

-----------------------------------------------------------
-- 0. RESET TABLES (Cleanup existing data)
-----------------------------------------------------------
DELETE FROM [Member];
DELETE FROM [Package];
GO

-----------------------------------------------------------
-- 1. INSERT PACKAGES
-----------------------------------------------------------
DECLARE @Pkg1M UNIQUEIDENTIFIER = NEWID();
DECLARE @Pkg3M UNIQUEIDENTIFIER = NEWID();
DECLARE @Pkg6M UNIQUEIDENTIFIER = NEWID();
DECLARE @Pkg12M UNIQUEIDENTIFIER = NEWID();
DECLARE @PkgPT3M UNIQUEIDENTIFIER = NEWID();

INSERT INTO [Package] (package_id, package_name, duration, price, with_trainer, is_active)
VALUES
(@Pkg1M,  N'Gói 1 tháng',           1,   500000,  0, 1),
(@Pkg3M,  N'Gói 3 tháng',           3,  1200000,  0, 1),
(@Pkg6M,  N'Gói 6 tháng',           6,  2000000,  0, 1),
(@Pkg12M, N'Gói 12 tháng',         12,  3500000,  0, 1);

GO

-----------------------------------------------------------
-- 2. INSERT MEMBERS (gender: 1 = Nam, 0 = Nữ)
-----------------------------------------------------------
DECLARE @M1 UNIQUEIDENTIFIER = NEWID();
DECLARE @M2 UNIQUEIDENTIFIER = NEWID();
DECLARE @M3 UNIQUEIDENTIFIER = NEWID();
DECLARE @M4 UNIQUEIDENTIFIER = NEWID();
DECLARE @M5 UNIQUEIDENTIFIER = NEWID();
DECLARE @M6 UNIQUEIDENTIFIER = NEWID();

INSERT INTO [Member] (
    member_id, member_name, gender, date_of_birth, age,
    phone_number, email, remaining_duration, register_date,
    has_trainer, is_expired, is_active
)
VALUES
(@M1, N'Nguyễn Văn An',       1, '1998-03-15', 28, '0901234567', 'an.nguyen@email.com',       45, '2025-11-01', 0, 0, 1),
(@M2, N'Trần Thị Bình',       0, '2000-07-22', 25, '0912345678', 'binh.tran@email.com',       12, '2026-02-10', 0, 0, 1),
(@M3, N'Lê Hoàng Nam',        1, '1995-11-08', 30, '0987654321', 'nam.le@email.com',         0, '2024-06-01', 1, 1, 0),
(@M4, N'Phạm Minh Tuấn',     1, '2001-01-30', 25, '0933445566', 'tuan.pham@email.com',       90, '2025-12-20', 1, 0, 1),
(@M5, N'Hoàng Thị Mai',      0, '1999-05-18', 26, '0977889900', 'mai.hoang@email.com',      180, '2026-01-05', 0, 0, 1),
(@M6, N'Đỗ Quốc Huy',         1, '1997-09-12', 28, '0966112233', 'huy.do@email.com',         7, '2026-03-20', 0, 0, 1);