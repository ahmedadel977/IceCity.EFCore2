using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories;
using IceCity.EFCore2.Repositories.Interfaces;

public class HeaterRepository
    : GenericRepository<Heater>, IHeaterRepository
{
    public HeaterRepository(AppDbContext context)
        : base(context)
    {
    }
}