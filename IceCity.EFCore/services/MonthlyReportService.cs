using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;

namespace IceCity.EFCore.Services;

public class MonthlyReportService
{
    private readonly AppDbContext context;

    public MonthlyReportService(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(MonthlyReport report)
    {
        context.MonthlyReports.Add(report);
        context.SaveChanges();
    }

    public List<MonthlyReport> GetAll()
    {
        return context.MonthlyReports.ToList();
    }

    public MonthlyReport? GetById(int id)
    {
        return context.MonthlyReports.Find(id);
    }

    public void Update(MonthlyReport report)
    {
        context.MonthlyReports.Update(report);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var report = context.MonthlyReports.Find(id);

        if (report != null)
        {
            context.MonthlyReports.Remove(report);
            context.SaveChanges();
        }
    }
}