# IceCity - Week 6 (Advanced Entity Framework Core)

## Overview

This project is part of the Backend .NET Intermediate Roadmap.

The goal of Week 6 is to apply advanced Entity Framework Core concepts to improve database performance, scalability, and maintainability for the IceCity system.

---

# Technologies

- .NET 9
- C#
- Entity Framework Core 9
- SQL Server

---

# Features

## Loading Strategies

- Eager Loading
- Explicit Loading
- Lazy Loading Proxies
- Include()
- ThenInclude()

---

## Advanced Queries

Implemented LINQ queries for:

- Top 10 Houses by Monthly Cost
- Owners Ordered by Total Heating Consumption
- Daily Usage Between Two Dates
- Monthly Reports for a Specific Year
- Houses Without Heaters
- Houses With More Than Three Heaters
- Average Heating Hours by City Zone

---

## Pagination

Implemented server-side pagination using:

- Skip()
- Take()

---

## DTO Projection

Created DTOs using Select().

### DTOs

- HouseSummaryDto
- OwnerDashboardDto
- MonthlyReportDto

---

## Transactions

Implemented database transactions when generating monthly reports.

Operations executed in a single transaction:

- Save Daily Usage
- Calculate Monthly Cost
- Save Monthly Report

Rollback is performed if any operation fails.

---

## Optimistic Concurrency

Implemented optimistic concurrency using RowVersion.

Handled:

- DbUpdateConcurrencyException

---

## Performance Optimization

Implemented:

- AsNoTracking()
- Split Queries
- Batch Updates
- Batch Deletes

Performance comparison included before and after optimization.

---

## Soft Delete

Implemented Soft Delete using:

- SaveChangesInterceptor
- Global Query Filters

Deleted records are marked as deleted instead of being permanently removed.

---

## Generic Repository Pattern

Implemented:

- IGenericRepository<T>
- GenericRepository<T>

Repositories:

- OwnerRepository
- HouseRepository
- HeaterRepository
- DailyUsageRepository
- MonthlyReportRepository

All Services were refactored to use repositories instead of accessing DbContext directly.

---

# Project Structure

```text
IceCity.EFCore
│
├── Data
├── Entities
├── Configurations
├── DTOs
├── Interceptors
├── Repositories
│   ├── Interfaces
│   └── Implementations
├── Services
├── Migrations
├── Docs
└── Program.cs
```

---

# Project Highlights

- Clean Project Structure
- Advanced EF Core Features
- Generic Repository Pattern
- DTO Projection
- Loading Strategies
- Transactions
- Optimistic Concurrency
- Performance Optimization
- Soft Delete

---

# Commit

```
Week6-EFCore-Advanced
```

---

# Author

Ahmed Adel
Backend .NET Developer
