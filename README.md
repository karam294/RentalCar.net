✅ Setting Up the Database
Open MySQL Workbench (or your preferred MySQL client).

Open the database.sql file included in the project.

Run the script to create the i3332 database and its tables.

🔧 Configure the Connection
Open the configuration file (e.g., web.config, .env, or wherever your database connection string is stored).

Update the following values as needed:

Server name / host

Username

Password

Database name

Make sure the values match your local MySQL setup.

# Car Rental System (ASP.NET WebForms + MySQL)

This is a simple car rental web application built using **ASP.NET WebForms** (.NET Framework) and **MySQL**. It supports user authentication and provides functionality for both normal users and administrators.

---

## 🚗 Features

### 👤 Normal User:
- Sign up and log in
- View available cars
- Book cars for a selected date range
- Get feedback if the car is already booked

### 🛠️ Admin User:
- Log in to access admin panel
- Add new cars (with image, type, availability, price)
- Edit car listings
- Delete car listings

---

## 🛠️ Tech Stack

- **ASP.NET WebForms**
- **MySQL Database**
- **Bootstrap 5 (UI Styling)**
- **C# / ADO.NET for DB interaction**

---

## 🔧 Installation & Setup

### 1. Prerequisites
- Visual Studio with ASP.NET WebForms support
- MySQL installed locally
- .NET Framework (compatible with WebForms)

### 2. Clone the Repository

```bash
git clone https://github.com/yourusername/CarRentalSystem.git
cd CarRentalSystem
