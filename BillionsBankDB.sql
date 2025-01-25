/*=============================================================
FileName: Create_Database_And_Tables.sql
Programmer: Mpotjo Nyofane
Description: This file will create the database and tables with the necessary constraints.
=============================================================*/

--CREATE DATABASE BillionsBankDB 
Use BillionsBankDB
GO

-- Create table for security questions
CREATE TABLE SecurityQuestion
(
	SecurityQuestionId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SecurityQuestionName VARCHAR(50) NOT NULL
)

-- Insert some sample security questions into the SecurityQuestion table
INSERT INTO SecurityQuestion VALUES ('What is your ID Number');
INSERT INTO SecurityQuestion VALUES ('What is your email address');
INSERT INTO SecurityQuestion VALUES ('What is the name of your street');

-- Create table for user accounts
CREATE TABLE Account
(
	AccountId int PRIMARY KEY IDENTITY(1,1),
	AccountNumber VARCHAR(30),
	AccountType VARCHAR(20),
	UserName VARCHAR(30),
	Gender VARCHAR(10),
	Email VARCHAR(50),
	Address VARCHAR(Max),
	SecurityQuestionId int FOREIGN KEY REFERENCES SecurityQuestion(SecurityQuestionId),
	Answer VARCHAR(30),
	Amount int ,
	Password VARCHAR(30)
)

-- Create table for transactions
CREATE TABLE [Transaction]
(
	TransactionID int PRIMARY KEY IDENTITY(1,1),
	SenderAccountId int FOREIGN KEY REFERENCES Account(AccountId),
	ReceiverAccountId int FOREIGN KEY REFERENCES Account(AccountId),
	RecipientName VARCHAR(30),
	MobileNumber VARCHAR(20),
	Amount int ,
	TransactionDate VARCHAR(30),
	Reference VARCHAR(30)
)
