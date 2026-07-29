using IceCity.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.Queries
{
    public static class PerformanceOptimization
    {
        public static void AsNoTrackingExample(AppDbContext context)
        {
            var reports = context.MonthlyReports
             .AsNoTracking()
               .ToList();



        }

        public static void AsSplitQueryExample(AppDbContext context)
        {
            var owners = context.Owners
        .Include(o => o.Houses)
            .ThenInclude(h => h.heaters)
        
        .AsSplitQuery()
        .ToList();

            Console.WriteLine($"Owners Count: {owners.Count}");



        }

        public static void ExecuteUpdateExample(AppDbContext context)
        {
            var rowsAffected = context.Heaters
          .Where(h => h.PowerValue < 2000)
          .ExecuteUpdate(setters => setters
           .SetProperty(h => h.PowerValue, h => 2000));

            Console.WriteLine($"Updated Rows: {rowsAffected}");


        }

        public static void ExecuteDeleteExample(AppDbContext context)
        {
            var rowsAffected = context.Heaters
          .Where(h => h.PowerValue < 1000)
          .ExecuteDelete();

            Console.WriteLine($"Deleted Rows: {rowsAffected}");

        }

        
        
    }
}
