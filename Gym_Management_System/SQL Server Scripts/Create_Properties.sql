USE GymManagementSystem;
GO

DELETE FROM [Role];
GO

INSERT INTO [Role] (role_id, role_name) VALUES 
(1, 'Admin'), 
(2, 'Manager'), 
(3, 'Receptionist'), 
(4, 'Trainer');

