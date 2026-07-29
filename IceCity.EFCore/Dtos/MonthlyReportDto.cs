namespace IceCity.EFCore.Dtos
{
    public class MonthlyReportDto
    {
        public int ReportId { get; set; }
        public DateTime ReportMonth { get; set; }
        public decimal MonthlyAverageCost { get; set; }
    }

}
