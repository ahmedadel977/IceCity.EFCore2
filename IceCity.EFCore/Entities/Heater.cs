namespace IceCity.EFCore.Entities
{
    public class Heater
    {
        public int HeaterId { get; set; }

        public int HouseId { get; set; }

        public string HeaterType { get; set; } = null!;

        public decimal PowerValue { get; set; }

        
        public House House { get; set; } = null!;

        public List<DailyUsage> DailyUsages { get; set; } = new List<DailyUsage>();
    }



}
