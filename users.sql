CREATE TABLE [dbo].[users] (
    [id]           INT IDENTITY (1,1) NOT NULL,
    [email]        VARCHAR(255) NOT NULL,
    [username]     VARCHAR(100) NOT NULL,
    [password]     VARCHAR(255) NOT NULL,
    [role]         VARCHAR(20) NOT NULL DEFAULT 'seller', -- admin / seller
    [date_created] DATE DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([id] ASC)
);

INSERT INTO [dbo].[users] ([email], [username], [password], [role]) VALUES 
('admin01@gmail.com', 'admin01', '123456', 'admin'),
('admin02@gmail.com', 'admin02', '123456', 'admin');


INSERT INTO [dbo].[users] ([email], [username], [password], [role]) VALUES 
('seller01@gmail.com', 'seller01', 'seller123', 'seller'),
('seller02@gmail.com', 'seller02', 'seller123', 'seller');

SELECT * FROM [dbo].[users] ORDER BY [role], [username];

SELECT [role], COUNT(*) as [count] 
FROM [dbo].[users] 
GROUP BY [role];