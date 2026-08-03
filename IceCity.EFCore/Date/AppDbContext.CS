using IceCity.EFCore.Date.intercaptor;
using IceCity.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.Data

{
    public class AppDbContext : DbContext
    {
       

        public DbSet<Owner> Owners { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Heater> Heaters { get; set; }
        public DbSet<DailyUsage> DailyUsages { get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }
        
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
