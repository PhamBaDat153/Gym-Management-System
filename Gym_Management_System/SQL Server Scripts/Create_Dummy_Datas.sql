USE db48275;
GO

-- 1. Delete existing data (in order of dependency - child tables first)
DELETE FROM [Receipt];
DELETE FROM [MemberReport];
DELETE FROM [RevenueReport];
DELETE FROM [Member];
DELETE FROM [Package];
DELETE FROM [PaymentMethod];
DELETE FROM [SessionStatus];
DELETE FROM [Role];
GO

-- 2. Insert Role Data
INSERT INTO [Role] (role_id, role_name) VALUES 
(1, N'Receptionist'),
(2, N'Manager'),
(3, N'Admin'),
(4, N'Trainer');
GO

-- 3. Insert SessionStatus Data
INSERT INTO [SessionStatus] (status_id, status) VALUES 
(1, N'Chưa diễn ra'),
(2, N'Đang diễn ra'),
(3, N'Đã hoàn thành');
GO

-- 4. Insert PaymentMethod Data
INSERT INTO [PaymentMethod] (method_id, method_name) VALUES 
(1, N'Tiền mặt'), 
(2, N'Quẹt thẻ'), 
(3, N'Chuyển khoản');
GO

-- 5. Insert Package Data
INSERT INTO [Package] (package_id, package_name, duration, price, with_trainer, is_active) VALUES 
(NEWID(), N'Basic Package', 30, 1500000, 0, 1),
(NEWID(), N'Standard Package', 90, 3900000, 0, 1),
(NEWID(), N'Premium Package', 180, 6900000, 1, 1),
(NEWID(), N'Elite Package', 365, 12000000, 1, 1),
(NEWID(), N'Starter Package', 15, 999000, 0, 1);
GO

-- 6. Insert 20+ Member Data
INSERT INTO [Member] (member_id, member_name, gender, date_of_birth, age, phone_number, email, remaining_duration, register_date, has_trainer, is_expired, is_active) VALUES 
(NEWID(), N'Nguyễn Văn A', 1, '1995-05-15', 30, '0912345678', 'nguyenvana@email.com', 25, '2026-01-10', 0, 0, 1),
(NEWID(), N'Trần Thị B', 0, '1998-08-22', 27, '0923456789', 'tranthib@email.com', 60, '2025-12-01', 1, 0, 1),
(NEWID(), N'Phạm Văn C', 1, '2000-03-10', 25, '0925345678', 'phamvanc@email.com', 0, '2025-10-15', 0, 1, 0),
(NEWID(), N'Lê Thị D', 0, '1999-07-20', 26, '0945678901', 'lethid@email.com', 45, '2026-02-05', 0, 0, 1),
(NEWID(), N'Hoàng Văn E', 1, '1997-11-08', 28, '0956789012', 'hoangvane@email.com', 90, '2026-03-20', 1, 0, 1),
(NEWID(), N'Đỗ Minh F', 0, '2001-02-14', 24, '0967890123', 'dominf@email.com', 15, '2026-04-01', 0, 0, 1),
(NEWID(), N'Võ Thanh G', 1, '1996-09-30', 29, '0978901234', 'vothanhg@email.com', 80, '2025-11-15', 1, 0, 1),
(NEWID(), N'Bùi Hương H', 0, '1999-01-12', 27, '0989012345', 'buihuongh@email.com', 30, '2026-01-25', 0, 0, 1),
(NEWID(), N'Dương Hải I', 1, '1994-06-18', 31, '0990123456', 'duonghaii@email.com', 50, '2025-09-10', 0, 0, 1),
(NEWID(), N'Cao Kiều J', 0, '2000-12-05', 25, '0901234567', 'caokieuj@email.com', 20, '2026-03-15', 0, 1, 1),
(NEWID(), N'Tạ Linh K', 1, '1998-04-22', 27, '0912345670', 'talinks@email.com', 70, '2025-10-20', 1, 0, 1),
(NEWID(), N'Vũ Minh L', 0, '2002-07-08', 23, '0923456780', 'vuminhl@email.com', 10, '2026-02-28', 0, 0, 1),
(NEWID(), N'Nông Nam M', 1, '1997-03-25', 28, '0934567891', 'nongnamm@email.com', 55, '2025-11-05', 0, 0, 1),
(NEWID(), N'Hồ Như N', 0, '1999-10-14', 26, '0945678902', 'honhun@email.com', 35, '2026-01-18', 0, 0, 1),
(NEWID(), N'Tống Oanh O', 0, '2001-05-30', 24, '0956789013', 'tongoanho@email.com', 5, '2026-04-05', 1, 0, 1),
(NEWID(), N'Lý Phương P', 0, '1996-11-20', 29, '0967890124', 'lyphuongp@email.com', 40, '2025-12-10', 0, 0, 1),
(NEWID(), N'Kiều Quân Q', 1, '1993-08-15', 32, '0978901235', 'kieuquanq@email.com', 85, '2025-08-22', 1, 0, 1),
(NEWID(), N'Phan Róc R', 1, '2000-01-09', 26, '0989012346', 'panrocr@email.com', 28, '2026-03-08', 0, 0, 1),
(NEWID(), N'Ứng Sánh S', 0, '1998-09-17', 27, '0990123457', 'unganhs@email.com', 65, '2025-10-30', 0, 0, 1),
(NEWID(), N'Tây Thái T', 1, '1995-12-03', 30, '0901234568', 'taythait@email.com', 45, '2026-02-12', 1, 0, 1),
(NEWID(), N'Uyển Ưng U', 0, '2002-04-11', 23, '0912345671', 'uyenungu@email.com', 12, '2026-04-10', 0, 0, 1);
GO

-- 7. Insert Receipt Data (linking Members to Packages)
INSERT INTO [Receipt] (receipt_id, member_id, package_id, total_amount, payment_date, payment_method) 
SELECT TOP 20
    NEWID(),
    m.member_id,
    (SELECT TOP 1 package_id FROM [Package] WHERE package_name IN (N'Basic Package', N'Standard Package', N'Premium Package', N'Elite Package') ORDER BY NEWID()),
    (SELECT TOP 1 price FROM [Package] WHERE package_name IN (N'Basic Package', N'Standard Package', N'Premium Package', N'Elite Package') ORDER BY NEWID()),
    m.register_date,
    CAST(FLOOR(RAND() * 3) + 1 AS INT)
FROM [Member] m
ORDER BY m.register_date;
GO

-- 7.1 Báo cáo (MemberReport, RevenueReport — khớp Create_Database.sql)
INSERT INTO [MemberReport] (report_id, total_member, monthly_new_member, monthly_loss_member, average_age, common_gender, report_date) VALUES
(NEWID(), 120, 15, 3, 28, 1, '2026-04-01'),
(NEWID(), 118, 8, 2, 29, 0, '2026-04-10'),
(NEWID(), 122, 12, 4, 27, 1, '2026-04-18');
GO

INSERT INTO [RevenueReport] (report_id, best_sell_package, least_sell_package, total_package_sold, total_amount, total_cost, net_profit, report_date) VALUES
(NEWID(), N'Premium Package', N'Starter Package', 42, 185000000, 95000000, 90000000, '2026-04-01'),
(NEWID(), N'Elite Package', N'Starter Package', 38, 210000000, 110000000, 100000000, '2026-04-12');
GO

-- 8. Verification: Check inserted data
SELECT 'Role Count:' AS [Check], COUNT(*) AS [Count] FROM [Role]
UNION ALL
SELECT 'SessionStatus Count:', COUNT(*) FROM [SessionStatus]
UNION ALL
SELECT 'PaymentMethod Count:', COUNT(*) FROM [PaymentMethod]
UNION ALL
SELECT 'Package Count:', COUNT(*) FROM [Package]
UNION ALL
SELECT 'Member Count:', COUNT(*) FROM [Member]
UNION ALL
SELECT 'Receipt Count:', COUNT(*) FROM [Receipt]
UNION ALL
SELECT 'MemberReport Count:', COUNT(*) FROM [MemberReport]
UNION ALL
SELECT 'RevenueReport Count:', COUNT(*) FROM [RevenueReport];
GO