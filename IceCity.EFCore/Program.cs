using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Drawing;
using System.Linq;

namespace IceCity.EFCore
{
    internal class Program
    {
        static void  Main(string[] args)
        {

            SimulateConcurrency();








        }
        static async Task adddate()
        {
            using var context = new AppDbContext();

            await context.Database.EnsureCreatedAsync();

            if (!await context.Set<Owner>().AnyAsync())
            {
                context.Set<Owner>().AddRange(SeedData.LoadOwners());
                await context.SaveChangesAsync();
            }

            if (!await context.Set<House>().AnyAsync())
            {
                context.Set<House>().AddRange(SeedData.LoadHouses());
                await context.SaveChangesAsync();
            }

            if (!await context.Set<Heater>().AnyAsync())
            {
                context.Set<Heater>().AddRange(SeedData.LoadHeaters());
                await context.SaveChangesAsync();
            }

            if (!await context.Set<DailyUsage>().AnyAsync())
            {
                context.Set<DailyUsage>().AddRange(SeedData.LoadDailyUsages());
                await context.SaveChangesAsync();
            }

            if (!await context.Set<MonthlyReport>().AnyAsync())
            {
                context.Set<MonthlyReport>().AddRange(SeedData.LoadMonthlyReports());
                await context.SaveChangesAsync();
            }



            Console.WriteLine("Seed Data Inserted Successfully.");

        }
            
         static void NoTrackingVSTracking()
        {
            using (var context = new AppDbContext())

            {
                Console.WriteLine("========== Tracking ==========");

                var owner = context.Owners.First();
                Console.WriteLine(context.Entry(owner).State);

                owner.Name = "Ahmed Updated";
                Console.WriteLine(context.Entry(owner).State);

                context.SaveChanges();
                Console.WriteLine(context.Entry(owner).State);


                Console.WriteLine("\n========== Added ==========");

                var newOwner = new Owner
                {
                    Name = "Ali",
                    Email = "ali@gmail.com",
                    Phone = "01011111111"
                };

                context.Owners.Add(newOwner);
                Console.WriteLine(context.Entry(newOwner).State);


                context.SaveChanges();


                Console.WriteLine("\n========== Deleted ==========");

                var deleteOwner = context.Owners.First();

                context.Owners.Remove(deleteOwner);
                Console.WriteLine(context.Entry(deleteOwner).State);

                
                context.SaveChanges();


                Console.WriteLine("\n========== Detached ==========");

                var detachedOwner = context.Owners.First();

                Console.WriteLine(context.Entry(detachedOwner).State);

                context.Entry(detachedOwner).State = EntityState.Detached;

                Console.WriteLine(context.Entry(detachedOwner).State);


                Console.WriteLine("\n========== No Tracking ==========");

                var noTrackingOwner = context.Owners
                    .AsNoTracking()
                    .First();

                Console.WriteLine(context.Entry(noTrackingOwner).State);

                Console.ReadKey();
            }


        }
        static void EagerLoading()
        {
            using var context = new AppDbContext();

            var owners = context.Owners
                .Include(o => o.Houses)
                    .ThenInclude(h => h.heaters)
                        .ThenInclude(h => h.DailyUsages)
                .ToList();

            foreach (var owner in owners)
            {
                Console.WriteLine($"Owner: {owner.Name}");

                foreach (var house in owner.Houses)
                {
                    Console.WriteLine($"  House: {house.Address}");

                    foreach (var heater in house.heaters)
                    {
                        Console.WriteLine($"    Heater: {heater.HeaterType}");

                        foreach (var usage in heater.DailyUsages)
                        {
                            Console.WriteLine($"      {usage.UsageDate:d} - {usage.HoursWorked} Hours");
                        }
                    }
                }
            }
        }
        static void HousesPagination(int pageNumber)
        {
            using (var context = new AppDbContext())
            {
                int size = 10;
                int total=context.Houses.Count();
                int totalpage=(int)Math.Ceiling((double)total/size);
                if (pageNumber > 0&&pageNumber<=totalpage)
                {
                    var houses = context.Houses.OrderBy(h=>h.HouseId).Skip((pageNumber-1)*size).Take(size);
                    foreach (var house in houses)
                    {
                        Console.WriteLine($"{house.HouseId} - {house.Address}");
                    }

                }



            }
        }
        static void GenerateMonthlyReport()

        {
            using var context = new AppDbContext();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                
                var usage = new DailyUsage
                {
                    HeaterId = 1,
                    UsageDate = DateTime.Now,
                    HoursWorked = 6
                };

                context.DailyUsages.Add(usage);
                context.SaveChanges();

                var totalHours = context.DailyUsages
                    .Where(d => d.HeaterId == usage.HeaterId &&
                                d.UsageDate.Month == DateTime.Now.Month &&
                                d.UsageDate.Year == DateTime.Now.Year)
                    .Sum(d => d.HoursWorked);

                decimal rate = 2; 
                decimal totalCost = totalHours * rate;

                
                var report = new MonthlyReport
                {
                    HouseId = usage.Heater.HouseId,
                    ReportMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                    MonthlyAverageCost = totalCost
                };

                context.MonthlyReports.Add(report);
                context.SaveChanges();

                transaction.Commit();

                Console.WriteLine("Monthly report generated successfully.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Console.WriteLine(ex.Message);
            }
        }
        static void SimulateConcurrency()
        {
            using var context1 = new AppDbContext();
            using var context2 = new AppDbContext();

            var heater1 = context1.Heaters.First(h => h.HeaterId == 1);
            var heater2 = context2.Heaters.First(h => h.HeaterId == 1);

           
            heater1.PowerValue =2500;
            context1.SaveChanges();

            Console.WriteLine("Engineer 1 updated the heater.");

            
            heater2.PowerValue= 3000;

            try
            {
                context2.SaveChanges();
                Console.WriteLine("Engineer 2 updated the heater.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Concurrency conflict!");
                Console.WriteLine("Another engineer has already modified this heater.");
            }
        }






    }
}