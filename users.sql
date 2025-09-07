CREATE TABLE [dbo].[users] (
    [id]           INT IDENTITY (1,1) NOT NULL,
    [email]        VARCHAR(255) NOT NULL,
    [username]     VARCHAR(100) NOT NULL,
    [password]     VARCHAR(255) NOT NULL,
    [role]         VARCHAR(20) NOT NULL DEFAULT 'seller', -- admin / seller
    [date_created] DATE DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([id] ASC)
);
