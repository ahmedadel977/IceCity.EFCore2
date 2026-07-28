using IceCity.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceCity.EFCore.Data.conf
{
    public class DailyUsageConfiguration : IEntityTypeConfiguration<DailyUsage>
    {
        public void Configure(EntityTypeBuilder<DailyUsage> builder)
        {
            builder.HasKey(x => x.DailyUsageId);
            builder .Property(x=>x.DailyUsageId).ValueGeneratedNever();
            builder.Property(x => x.HoursWorked)
                .HasPrecision(5, 2);

            builder.Property(x => x.HeaterValue)
                .HasPrecision(10, 2);

            builder.HasOne(x => x.Heater)
                .WithMany(x => x.DailyUsages)
                .HasForeignKey(x => x.HeaterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.House)
                .WithMany(x => x.dailyUsages)
                .HasForeignKey(x => x.HouseId);
               

            builder.ToTable("DailyUsages");
        }

    }


}
    