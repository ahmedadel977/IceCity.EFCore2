using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;

namespace IceCity.EFCore.Services;

public class HouseService
{
    private readonly AppDbContext context;

    public HouseService(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(House house)
    {
        context.Houses.Add(house);
        context.SaveChanges();
    }

    public List<House> GetAll()
    {
        return context.Houses.ToList();
    }

    public House? GetById(int id)
    {
        return context.Houses.Find(id);
    }

    public void Update(House house)
    {
        context.Houses.Update(house);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var house = context.Houses.Find(id);

        if (house != null)
        {
            context.Houses.Remove(house);
            context.SaveChanges();
        }
    }
}
