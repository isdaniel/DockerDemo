-- create a test database
CREATE DATABASE Sales;
GO

-- create a test table
USE [Sales];
GO
CREATE TABLE CUSTOMER
(
    [CustomerID] [INT] NOT NULL,
    [SalesAmount] [DECIMAL] NOT NULL
);
GO


-- add a PK (we can't replicate without one)
ALTER TABLE CUSTOMER ADD PRIMARY KEY (CustomerID);
