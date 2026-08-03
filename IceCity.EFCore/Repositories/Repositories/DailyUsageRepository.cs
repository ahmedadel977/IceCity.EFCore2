using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories;
using IceCity.EFCore2.Repositories.Interfaces;

public class DailyUsageRepository
    : GenericRepository<DailyUsage>, IDailyUsageRepository
{
    public DailyUsageRepository(AppDbContext context)
        : base(context)
    {
    }
}