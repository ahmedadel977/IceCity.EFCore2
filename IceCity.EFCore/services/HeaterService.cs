using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;

namespace IceCity.EFCore.Services;

public class HeaterService
{
    private readonly AppDbContext context;

    public HeaterService(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(Heater heater)
    {
        context.Heaters.Add(heater);
        context.SaveChanges();
    }

    public List<Heater> GetAll()
    {
        return context.Heaters.ToList();
    }

    public Heater? GetById(int id)
    {
        return context.Heaters.Find(id);
    }

    public void Update(Heater heater)
    {
        context.Heaters.Update(heater);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var heater = context.Heaters.Find(id);

        if (heater != null)
        {
            context.Heaters.Remove(heater);
            context.SaveChanges();
        }
    }
}
