# ❄️ IceCity – Entity Framework Core Journey

> A backend simulation project built with **C#**, **.NET 9**, **Entity Framework Core 9**, and **SQL Server**.

---

# 📖 About the Project

IceCity is a backend simulation project that models a city heating management system.

The system allows managing:

- 👤 Owners
- 🏠 Houses
- 🔥 Heaters
- 📊 Daily Heating Usage
- 📅 Monthly Reports

The main objective of this project is to practice **Entity Framework Core** by gradually building a real-world application while improving its architecture, maintainability, and performance.

---

# 🚀 Week 5 — Entity Framework Core Fundamentals

During Week 5, the project was migrated from raw SQL to Entity Framework Core and the database layer was fully implemented.

### ✔️ Implemented

- DbContext & DbSet
- Fluent API Configurations
- One-to-Many Relationships
- Many-to-Many Relationships
- Data Seeding
- EF Core Migrations
- CRUD Operations
- Change Tracking
- SaveChanges Interceptors
- Soft Delete
- Global Query Filters

**Result**

A clean, maintainable, and fully configured data layer powered by Entity Framework Core.

---

# ⚡ Week 6 — Advanced Entity Framework Core

Week 6 focused on applying advanced EF Core concepts used in enterprise applications.

## 📌 Loading Strategies

- Eager Loading
- Explicit Loading
- Lazy Loading
- Include()
- ThenInclude()

---

## 📌 Advanced Queries

- Top 10 Houses by Monthly Cost
- Owners Ordered by Total Heating Consumption
- Daily Usage Between Two Dates
- Monthly Reports by Year
- Houses Without Heaters
- Houses With More Than Three Heaters
- Average Heating Hours by City Zone

---

## 📌 Pagination

- Skip()
- Take()

---

## 📌 DTO Projection

- HouseSummaryDto
- OwnerDashboardDto
- MonthlyReportDto

---

## 📌 Transactions

- Database Transactions
- Rollback on Failure

---

## 📌 Optimistic Concurrency

- RowVersion
- DbUpdateConcurrencyException
- Optimistic Concurrency

---

## 📌 Performance Optimization

- AsNoTracking()
- Split Queries
- Batch Updates
- Batch Deletes

---

## 📌 Repository Pattern

- IGenericRepository<T>
- GenericRepository<T>
- OwnerRepository
- HouseRepository
- HeaterRepository
- DailyUsageRepository
- MonthlyReportRepository

All services were refactored to use repositories instead of accessing `DbContext` directly.

---

# 🛠️ Technologies

- C#
- .NET 9
- Entity Framework Core 9
- SQL Server
- LINQ

---

# 📂 Project Structure

```text
IceCity.EFCore
│
├── Data
├── Entities
├── Configurations
├── DTOs
├── Repositories
│   ├── Interfaces
│   └── Implementations
├── Services
├── Interceptors
├── Migrations
├── Docs
└── Program.cs
```

---

# 🎯 Learning Outcomes

Through this project, I gained practical experience with:

- Entity Framework Core Fundamentals
- Fluent API & Entity Configuration
- Database Relationships
- LINQ & Advanced Queries
- DTO Projection
- Pagination
- Database Transactions
- Optimistic Concurrency
- Performance Optimization
- Soft Delete
- Interceptors
- Generic Repository Pattern
- Building a Clean and Maintainable Data Layer

---

# 👨‍💻 Author

**Ahmed Adel**

Backend .NET Developer
