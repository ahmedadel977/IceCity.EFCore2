using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IceCity.EFCore
{
    internal class Program
    {
        static void  Main(string[] args)
        {



            



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

                // إذا أردت تنفيذ الحذف
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


    }
}