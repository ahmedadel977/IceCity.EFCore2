# ❄️ IceCity.EFCore

A Code-First Entity Framework Core implementation for the IceCity Heating System.

This project is part of the Backend .NET Intermediate Roadmap and demonstrates how to build a complete data access layer using Entity Framework Core with SQL Server.

---

## 📌 Features

- Entity Framework Core Code First
- SQL Server Integration
- Fluent API Configurations
- Entity Relationships
- Database Migrations
- Seed Data
- CRUD Services
- Change Tracking Demonstration
- Monthly Report Storage
- Dependency Injection Ready Structure

---

## 🏗️ Project Structure

```
IceCity.EFCore
│
├── Configurations/
├── Data/
├── Entities/
├── Migrations/
├── SeedData/
├── Services/
├── Docs/
├── Program.cs
└── AppDbContext.cs
```

---

## 🗄️ Database Design

### Entities

- Owner
- House
- Heater
- DailyUsage
- MonthlyReport

### Relationships

- One Owner → Many Houses
- One House → Many Heaters
- One House → Many DailyUsages
- One Heater → Many DailyUsages
- One House → Many MonthlyReports

---

## ⚙️ Technologies

- C#
- .NET 9
- Entity Framework Core 9
- SQL Server
- LINQ
- Dependency Injection
- Fluent API

---

## 🚀 Implemented Features

### ✅ Entity Configuration

- Primary Keys
- Foreign Keys
- Required Fields
- Max Length
- Decimal Precision
- Delete Behaviors

---

### ✅ CRUD Operations

Implemented service layer for:

- Owner
- House
- Heater
- DailyUsage
- MonthlyReport

Each service supports:

- Create
- Read
- GetById
- Update
- Delete

---

### ✅ Database Migration

```bash
Add-Migration Initial
Update-Database
```

---

### ✅ Seed Data

Automatically generates:

| Entity | Count |
|---------|------:|
| Owners | 10 |
| Houses | 20 |
| Heaters | 40 |
| DailyUsage | 500 |
| MonthlyReports | 20 |

---

### ✅ Change Tracking Demo

The project demonstrates:

- Tracking
- No Tracking
- Added
- Modified
- Deleted
- Detached
- Unchanged

---

### ✅ Monthly Reports

Monthly reports are generated and stored without overwriting previous reports.

---

## 📷 Example

```csharp
var owner = context.Owners.First();

Console.WriteLine(context.Entry(owner).State);

owner.FullName = "Ahmed";

Console.WriteLine(context.Entry(owner).State);

context.SaveChanges();

Console.WriteLine(context.Entry(owner).State);
```

---

## 🧠 Learning Outcomes

This project helped me understand:

- EF Core Architecture
- DbContext
- DbSet
- Code First Approach
- Fluent API
- Migrations
- LINQ with EF Core
- Change Tracker
- CRUD Operations
- Repository-like Service Layer
- SQL Server Integration

---

## 📚 Course

Backend .NET Intermediate Roadmap

Week 5 — Entity Framework Core Fundamentals

---

## 👨‍💻 Author

Ahmed Adel

- GitHub: https://github.com/ahmedadel977
- LinkedIn: *(Add your LinkedIn profile here)*

---

## ⭐ If you found this project useful

Give it a ⭐ on GitHub.
