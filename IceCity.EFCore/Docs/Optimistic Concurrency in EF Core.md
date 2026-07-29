# Week 6 - Optimistic Concurrency in EF Core

## Objective

The objective of this task is to understand how EF Core handles concurrent updates and prevents data loss when multiple users modify the same record simultaneously.

---

## Entity Configuration

### Heater Entity

```csharp
public class Heater
{
    public int HeaterId { get; set; }

    public int Power { get; set; }

    public byte[] RowVersion { get; set; }
}
```

### Fluent API Configuration

```csharp
public class HeaterConfiguration : IEntityTypeConfiguration<Heater>
{
    public void Configure(EntityTypeBuilder<Heater> builder)
    {
        builder.Property(h => h.RowVersion)
               .IsRowVersion();
    }
}
```

---

## Migration

After adding the `RowVersion` property, a migration was created and the database was updated.

```powershell
Add-Migration AddRowVersion
Update-Database
```

---

## Concurrency Simulation

```csharp
using Microsoft.EntityFrameworkCore;

using var context1 = new AppDbContext();
using var context2 = new AppDbContext();

// Engineer 1 reads the heater
var heater1 = context1.Heaters.First(h => h.HeaterId == 1);

// Engineer 2 reads the same heater
var heater2 = context2.Heaters.First(h => h.HeaterId == 1);

// Engineer 1 updates the heater
heater1.Power = 2500;
context1.SaveChanges();

Console.WriteLine("Engineer 1 updated the heater successfully.");

try
{
    // Engineer 2 updates the outdated copy
    heater2.Power = 3000;
    context2.SaveChanges();

    Console.WriteLine("Engineer 2 updated the heater successfully.");
}
catch (DbUpdateConcurrencyException)
{
    Console.WriteLine("Concurrency conflict detected!");
    Console.WriteLine("Another engineer has already modified this heater.");
}
```

---

## Explanation

1. Two separate `DbContext` instances simulate two different engineers working at the same time.
2. Both engineers read the same `Heater` record from the database.
3. The first engineer updates and saves the record successfully.
4. SQL Server automatically updates the `RowVersion` value.
5. The second engineer attempts to save an outdated copy of the same record.
6. During `SaveChanges()`, EF Core compares the original `RowVersion` with the current value in the database.
7. Since the values do not match, EF Core throws a `DbUpdateConcurrencyException`, preventing the newer data from being overwritten.

---

## How Optimistic Concurrency Works

Optimistic Concurrency allows multiple users to read the same data without locking it. Instead of preventing concurrent access, EF Core checks whether the data has changed before saving. If another user has already modified the record, EF Core detects the conflict using the `RowVersion` value and throws a `DbUpdateConcurrencyException`.

---

## What I Learned

- How Optimistic Concurrency works in EF Core.
- How to use `RowVersion` as a concurrency token.
- How to configure concurrency using Fluent API.
- How EF Core detects concurrent updates.
- How to handle `DbUpdateConcurrencyException`.
- Why multiple `DbContext` instances are used to simulate multiple users.

---

## Conclusion

This task demonstrated how EF Core protects data integrity in multi-user applications using **Optimistic Concurrency**. By comparing the `RowVersion` before saving changes, EF Core prevents lost updates and ensures that users do not accidentally overwrite each other's modifications.