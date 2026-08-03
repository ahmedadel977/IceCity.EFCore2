using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories;
using IceCity.EFCore2.Repositories.Interfaces;

public class MonthlyReportRepository
    : GenericRepository<MonthlyReport>, IMonthlyReportRepository
{
    public MonthlyReportRepository(AppDbContext context)
        : base(context)
    {
    }
}