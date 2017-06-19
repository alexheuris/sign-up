CREATE DATABASE SignUp;
GO

USE SignUp;
GO

CREATE TABLE users(
    id int IDENTITY(0,1) PRIMARY KEY,
    email varchar(MAX) NOT NULL,
    password varchar(128) NOT NULL
);
GO
