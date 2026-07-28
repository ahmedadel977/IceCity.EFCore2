using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace IceCity.EFCore.Entities
    {

        public class DailyUsage
        {
            public int DailyUsageId { get; set; }

            public int HeaterId { get; set; }

            public int HouseId { get; set; }

            public DateTime UsageDate { get; set; }

            public decimal HoursWorked { get; set; }

            public decimal HeaterValue { get; set; }

            // Navigation Properties
            public Heater Heater { get; set; } = null!;

            public House House { get; set; } = null!;
        }
    }

