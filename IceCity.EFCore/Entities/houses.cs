using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IceCity.EFCore.Entities
{
   public class House
    {
       public int HouseId { get; set; }
       public int OwnerId { get; set; }
        public string Address { get; set; } 
        public string CityZone { get; set; }
        public Owner owner { get; set; } = null!;
        public List<Heater> heaters { get; set; } = new List<Heater>();
        public List< DailyUsage> dailyUsages { get;  set; }= new List<DailyUsage> () ;
        public List <MonthlyReport> monthlyReports { get; set; }= new List<MonthlyReport> () ;

    }



}
