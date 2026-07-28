namespace IceCity.EFCore.Entities
{
    public class MonthlyReport
    {
        public int ReportId { get; set; }

        public int HouseId { get; set; }

        public DateTime ReportMonth { get; set; }

        public decimal TotalWorkingHours { get; set; }

        public decimal MedianHeaterValue { get; set; }

        public decimal MonthlyAverageCost { get; set; }

        public DateTime CreatedAt { get; set; }

      
        public House House { get; set; } = null!;
    }



}
