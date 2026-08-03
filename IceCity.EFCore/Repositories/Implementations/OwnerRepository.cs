using IceCity.EFCore.Data;
using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories;
using IceCity.EFCore2.Repositories.Interfaces;

public class OwnerRepository
    : GenericRepository<Owner>, IOwnerRepository
{
    public OwnerRepository(AppDbContext context)
        : base(context)
    {
    }
}
