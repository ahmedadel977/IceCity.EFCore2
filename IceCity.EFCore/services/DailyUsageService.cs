using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;

namespace IceCity.EFCore.Services;

public class DailyUsageService
{
    private readonly AppDbContext context;

    public DailyUsageService(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(DailyUsage dailyUsage)
    {
        context.DailyUsages.Add(dailyUsage);
        context.SaveChanges();
    }

    public List<DailyUsage> GetAll()
    {
        return context.DailyUsages.ToList();
    }

    public DailyUsage? GetById(int id)
    {
        return context.DailyUsages.Find(id);
    }

    public void Update(DailyUsage dailyUsage)
    {
        context.DailyUsages.Update(dailyUsage);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var dailyUsage = context.DailyUsages.Find(id);

        if (dailyUsage != null)
        {
            context.DailyUsages.Remove(dailyUsage);
            context.SaveChanges();
        }
    }
}
