# 🛒 E-Commerce Platform API

A production-oriented **RESTful E-Commerce Web API** built with **ASP.NET Core 8** following **Clean Architecture** principles. The project provides secure authentication, product management, shopping cart functionality, order processing, and role-based authorization while emphasizing scalability, maintainability, and clean code practices.

---

# 📌 Overview

This project simulates the backend of a modern e-commerce platform. It exposes RESTful endpoints that allow customers to browse products, manage shopping carts, place orders, and manage their accounts, while administrators can manage products, categories, users, and orders.

The project was developed to demonstrate backend development skills using Microsoft's modern .NET ecosystem and software engineering best practices.

---

# ✨ Features

## Authentication & Authorization

* User Registration
* Secure Login
* JWT Authentication
* Refresh Token Authentication
* Role-Based Authorization
* Email Verification
* Forgot Password
* Reset Password
* Change Password
* Logout
* Logout From All Devices

---

## Product Management

* Create Product
* Update Product
* Delete Product
* Get Product By Id
* Get All Products
* Product Search
* Product Filtering
* Product Sorting
* Pagination
* Product Specifications Pattern

---

## Category Management

* Create Category
* Get Categories

---

## Shopping Cart

* Create Cart Automatically
* Add Item To Cart
* Update Cart Item Quantity
* Remove Item
* Clear Cart
* View Cart

---

## Order Management

* Place Order
* View User Orders
* View Order Details
* Admin View All Orders
* Update Order Status

---

## Admin Features

* Dashboard Statistics
* Total Users
* Total Products
* Total Orders
* Manage Users
* Manage Products
* Manage Categories
* Manage Orders

---

# 🏗 Architecture

The project follows **Clean Architecture** to separate concerns and keep the codebase maintainable.

```text
Presentation Layer
        │
        ▼
Application Layer
        │
        ▼
Domain Layer
        │
        ▼
Infrastructure Layer
```

## Project Structure

```text
EcommerceAPI
│
├── EcommerceAPI.API
│   ├── Controllers
│   ├── Middleware
│   └── Program.cs
│
├── EcommerceAPI.Application
│   ├── DTOs
│   ├── Interfaces
│   ├── Services
│   ├── Specifications
│   └── Mapping
│
├── EcommerceAPI.Domain
│   ├── Entities
│   ├── Exceptions
│   └── Enums
│
└── EcommerceAPI.Infrastructure
    ├── Persistence
    ├── Repositories
    ├── Identity
    └── Migrations
```

---

# 🛠 Technologies

* ASP.NET Core 8
* C#
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* JWT Authentication
* Refresh Tokens
* LINQ
* Repository Pattern
* Unit of Work
* Specification Pattern
* Dependency Injection
* Swagger / OpenAPI
* AutoMapper

---

# 📂 Database

Main entities include:

* Users
* Roles
* Products
* Categories
* Shopping Carts
* Cart Items
* Orders
* Order Items
* Refresh Tokens

---

# 🔐 Authentication Flow

1. Register a new account.
2. Verify email.
3. Login.
4. Receive JWT Access Token.
5. Receive Refresh Token.
6. Access protected endpoints.
7. Refresh token when expired.
8. Logout or Logout From All Devices.

---

# 📖 API Endpoints

## Authentication

| Method | Endpoint                       |
| ------ | ------------------------------ |
| POST   | /api/Auth/Register             |
| POST   | /api/Auth/Login                |
| POST   | /api/Auth/RefreshToken         |
| POST   | /api/Auth/Logout               |
| POST   | /api/Auth/LogoutFromAllDevices |
| POST   | /api/Auth/ForgotPassword       |
| POST   | /api/Auth/ResetPassword        |
| GET    | /api/Auth/VerifyEmail          |
| POST   | /api/Auth/ChangePassword       |

---

## Products

| Method | Endpoint          |
| ------ | ----------------- |
| GET    | /api/Product      |
| GET    | /api/Product/{id} |
| POST   | /api/Product      |
| PUT    | /api/Product/{id} |
| DELETE | /api/Product/{id} |

Supports:

* Pagination
* Search
* Filtering
* Sorting

---

## Categories

| Method | Endpoint           |
| ------ | ------------------ |
| GET    | /api/Category      |
| POST   | /api/Category      |
| PUT    | /api/Category/{id} |
| DELETE | /api/Category/{id} |

---

## Cart

| Method | Endpoint             |
| ------ | -------------------- |
| GET    | /api/Cart            |
| POST   | /api/Cart/AddItem    |
| PUT    | /api/Cart/UpdateItem |
| DELETE | /api/Cart/RemoveItem |
| DELETE | /api/Cart/Clear      |

---

## Orders

| Method | Endpoint            |
| ------ | ------------------- |
| POST   | /api/Order          |
| GET    | /api/Order/MyOrders |
| GET    | /api/Order/{id}     |
| GET    | /api/Order/Admin    |

---

# 📦 Getting Started

## Clone Repository

```bash
git clone https://github.com/yourusername/EcommerceAPI.git
```

---

## Navigate

```bash
cd EcommerceAPI
```

---

## Configure Database

Update your **appsettings.json**

```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING"
}
```

---

## Apply Migrations

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet run
```

Swagger will be available at

```text
https://localhost:xxxx/swagger
```

---

# 📚 What I Learned

Throughout this project, I gained hands-on experience with:

* Clean Architecture
* SOLID Principles
* Repository Pattern
* Unit of Work
* Specification Pattern
* ASP.NET Identity
* JWT Authentication
* Refresh Tokens
* Email Verification
* Password Reset Flow
* Entity Framework Core
* LINQ
* Dependency Injection
* REST API Design
* DTO Mapping
* Swagger Documentation
* Pagination, Filtering, Searching, and Sorting

---

# 🤝 Contributing

Contributions, suggestions, and feedback are welcome.

Feel free to fork the repository and open a Pull Request.

---

# 📄 License

This project is licensed under the MIT License.

---

# 👩‍💻 Author

**Roaa Tolba**

Junior .NET Backend Developer

* LinkedIn: *https://www.linkedin.com/in/roaa-tolba-709b76226/*
* GitHub: *https://github.com/RoaaTolba*

---

## ⭐ If you found this project useful, consider giving it a star!
