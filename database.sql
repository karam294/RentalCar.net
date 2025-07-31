-- Create the database
CREATE DATABASE i3332;

-- Use the database
USE i3332;

-- Create the users table
CREATE TABLE users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(255),
    Email VARCHAR(255),
    Password VARCHAR(255),
    role VARCHAR(50)
);

-- Create the cars table
CREATE TABLE cars (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(100),
    Model VARCHAR(100),
    Type VARCHAR(100),
    PricePerDay DECIMAL(10,2),
    ImagePath VARCHAR(255),
    Available TINYINT(1)
);

-- Create the bookings table
CREATE TABLE bookings (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT,
    CarId INT,
    StartDate DATE,
    EndDate DATE,
    TotalPrice DECIMAL(10,2),
    BookingDate DATETIME,
    FOREIGN KEY (UserId) REFERENCES users(Id),
    FOREIGN KEY (CarId) REFERENCES cars(Id)
);
