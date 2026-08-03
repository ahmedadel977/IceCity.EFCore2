using IceCity.EFCore.Entities;

using IceCity.EFCore2.Repositories.Interfaces;

namespace IceCity.EFCore.Services;

public class MonthlyReportService
{
    private readonly IMonthlyReportRepository repository;

    public MonthlyReportService(IMonthlyReportRepository repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(MonthlyReport report)
    {
        await repository.AddAsync(report);
        await repository.SaveChangesAsync();
    }

    public async Task<List<MonthlyReport>> GetAllAsync()
    {
        return (await repository.GetAllAsync()).ToList();
    }

    public async Task<MonthlyReport?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(MonthlyReport report)
    {
        repository.Update(report);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var report = await repository.GetByIdAsync(id);

        if (report is null)
            return;

        repository.Delete(report);
        await repository.SaveChangesAsync();
    }
}