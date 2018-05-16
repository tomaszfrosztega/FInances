Create Database Finances

Use Finances

Create Table Users(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Password NVARCHAR(200) NOT NULL,
	Salt NVARCHAR(200) NOT NULL,
	UserName NVARCHAR(100) NOT NULL,
	FullName NVARCHAR(100),
	Role  NVARCHAR(10) NOT NULL,
	CreatedDate DATETIME NOT NULL,
	UpdatedAt DATETIME NOT NULL
)

select * from Users