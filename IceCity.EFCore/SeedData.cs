using IceCity.EFCore.Entities;

namespace IceCity.EFCore.Data;

public static class SeedData
{
    public static List<Owner> LoadOwners()
    {
        var owners = new List<  Owner>();
        for (int i = 1; i <= 10; i++)
        {
            owners.Add(new Owner
            {
                Id = i,
                Name = $"Owner {i}",
                Email = $"owner{i}@gmail.com",
                Phone = $"01000000{i:D2}"
            });
        }
        return owners;
    }

    public static List<House> LoadHouses()
    {
        var houses = new List<House>();
        for (int i = 1; i <= 20; i++)
        {
            houses.Add(new House
            {
                HouseId = i,
                OwnerId = ((i - 1) % 10) + 1,
                Address = $"Street {i}",
                CityZone = $"Zone {((i - 1) % 4) + 1}"
            });
        }
        return houses;
    }

    public static List<Heater> LoadHeaters()
    {
        var heaters = new List<Heater>();
        var random = new Random(1);
        string[] types = { "Electric", "Gas" };

        for (int i = 1; i <= 40; i++)
        {
            heaters.Add(new Heater
            {
                HeaterId = i,
                HouseId = ((i - 1) % 20) + 1,
                HeaterType = types[random.Next(types.Length)],
                PowerValue = random.Next(1500, 4001)
            });
        }

        return heaters;
    }

    public static List<DailyUsage> LoadDailyUsages()
    {
        var list = new List<DailyUsage>();
        var random = new Random(2);

        for (int i = 1; i <= 500; i++)
        {
            int houseId = random.Next(1, 21);
            list.Add(new DailyUsage
            {
                DailyUsageId = i,
                HouseId = houseId,
                HeaterId = ((houseId - 1) * 2) + random.Next(1, 3),
                UsageDate = DateTime.Today.AddDays(-random.Next(0, 30)),
                HoursWorked = random.Next(1, 25),
                HeaterValue = random.Next(1500, 4001)
            });
        }

        return list;
    }

    public static List<MonthlyReport> LoadMonthlyReports()
    {
        var reports = new List<MonthlyReport>();
        var random = new Random(3);

        for (int i = 1; i <= 20; i++)
        {
            reports.Add(new MonthlyReport
            {
                ReportId = i,
                HouseId = i,
                ReportMonth = new DateTime(2026, random.Next(1, 13), 1),
                TotalWorkingHours = random.Next(150, 450),
                MedianHeaterValue = random.Next(1800, 3500),
                MonthlyAverageCost = random.Next(500, 2500),
                CreatedAt = DateTime.Now
            });
        }

        return reports;
    }
}
