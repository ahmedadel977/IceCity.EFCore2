using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories;
using IceCity.EFCore2.Repositories.Interfaces;

public class HouseRepository
    : GenericRepository<House>, IHouseRepository
{
    public HouseRepository(AppDbContext context)
        : base(context)
    {
    }
}
