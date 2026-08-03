using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories.Interfaces;

namespace IceCity.EFCore.Services;

public class DailyUsageService
{
    private readonly IDailyUsageRepository repository;

    public DailyUsageService(IDailyUsageRepository repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(DailyUsage dailyUsage)
    {
        await repository.AddAsync(dailyUsage);
        await repository.SaveChangesAsync();
    }

    public async Task<List<DailyUsage>> GetAllAsync()
    {
        return (await repository.GetAllAsync()).ToList();
    }

    public async Task<DailyUsage?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(DailyUsage dailyUsage)
    {
        repository.Update(dailyUsage);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dailyUsage = await repository.GetByIdAsync(id);

        if (dailyUsage is null)
            return;

        repository.Delete(dailyUsage);
        await repository.SaveChangesAsync();
    }
}