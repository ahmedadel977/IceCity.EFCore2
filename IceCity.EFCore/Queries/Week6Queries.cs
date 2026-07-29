using IceCity.EFCore.Data;
using IceCity.EFCore.Dtos;
using IceCity.EFCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.Queries
{
    public static class Week6Queries
    {
        public static void Top10HighestMonthlyCost()
        {
            using (var context = new AppDbContext())
            {
                var houses = context.Houses.Select(h => new
                {
                    HouseId = h.HouseId,
                    Address = h.Address,
                    TotalCost = h.monthlyReports.Sum(x => x.MonthlyAverageCost)


                }
                ).OrderBy(x => x.TotalCost).Take(10);
                foreach (var house in houses)
                {
                    Console.WriteLine($"{house.HouseId} - {house.Address} - {house.TotalCost}");
                }


            }

        }
        public static void GetOwnersOrderedByHeatingConsumption()
        {
            using (var context = new AppDbContext())
            {
                var owner = context.Owners.Select(h => new
                {
                    ownername = h.Name,
                    TotalConsumption = h.Houses.SelectMany(h => h.dailyUsages)
                    .Sum(x => x.HoursWorked)


                }).OrderByDescending(x => x.TotalConsumption);
                foreach (var o in owner)
                {
                    Console.WriteLine($"{o.ownername},{o.TotalConsumption}");
                }


            }


        }
        static void DailyUsageBetweenDates(DateTime startDate, DateTime endDate)
        {
            using ( var context = new AppDbContext())
            {
                var usages = context.DailyUsages.Where(d => d.UsageDate >= startDate && d.UsageDate <= endDate);
                foreach (var usage in usages)
                {
                    Console.WriteLine($"{usage.UsageDate} - {usage.HoursWorked}");
                }
            }

        }
        static void MonthlyReportsByYear(int year)
        {
            using var context = new AppDbContext();

            var reports = context.MonthlyReports
                .Where(r => r.ReportMonth.Year == year)
                .ToList();

            foreach (var report in reports)
            {
                Console.WriteLine($"{report.ReportMonth:d}" );
            }
        }
        static void Houseswithoutheaters ()
        {
            using ( var context = new AppDbContext())
            {
                var houses = context.Houses.Where(h => !h.heaters.Any());
                foreach (var house in houses)
                {
                    Console.WriteLine($"{house.OwnerId},{house.HouseId}");
                }
            }

        }
        static void HousesWithMoreThanThreeHeaters()
        {
            using var context = new AppDbContext();

            var houses = context.Houses
                .Where(h => h.heaters.Count() > 3)
               ;

            foreach (var house in houses)
            {
                Console.WriteLine($"{house.HouseId} - {house.Address}");
            }
        }
        static void AverageHeatingHoursByCityZone()
        {
            using (var context = new AppDbContext())
            {
                var result = context.Houses.GroupBy(h => h.CityZone).
                    Select(h => new
                    {
                        cityzone = h.Key,
                        AVG = h.SelectMany(H => H.dailyUsages).Average(h => h.HoursWorked)

                    }
                    );
                foreach (var house in result)
                {
                    Console.WriteLine(house.cityzone, house.AVG);
                }

            }
            
            
        }
        static void GetHouseSummaryDto()
        {
            using var context = new AppDbContext();

            var houses = context.Houses
                .Select(h => new HouseSummaryDto
                {
                    HouseId = h.HouseId,
                    Address = h.Address,
                    CityZone = h.CityZone
                });
                

            foreach (var house in houses)
            {
                Console.WriteLine($"{house.HouseId} - {house.Address}");
            }
        }
        static void GetOwnerSummaryDto()
        {
            using var context = new AppDbContext();
            var owners = context.Owners.
                Select(o => new OwnerDashboardDto
                {
                    OwnerId = o.Id,
                    OwnerName = o.Name,


                }
                );
            foreach(var owner in owners)
            {
                Console.WriteLine(owner.OwnerName, owner.OwnerId);
            }
                
        }
        static void GetMonthlyReportrSummaryDto()
        {
            using var context = new AppDbContext();
            var MonthlyReport = context.MonthlyReports.
                Select(h => new MonthlyReportDto
                {
                    MonthlyAverageCost = h.MonthlyAverageCost,
                    ReportId = h.ReportId,
                    ReportMonth = h.ReportMonth,
                }
                );
            foreach (var monthlyReport in MonthlyReport)
            {
                Console.WriteLine($"{monthlyReport.ReportId}, {monthlyReport.ReportMonth}, {monthlyReport.MonthlyAverageCost}");
            }
        }






    }
}
