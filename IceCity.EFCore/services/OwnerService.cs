using IceCity.EFCore.Entities;

using IceCity.EFCore2.Repositories.Interfaces;

namespace IceCity.EFCore.Services;

public class OwnerService
{
    private readonly IOwnerRepository repository;

    public OwnerService(IOwnerRepository repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(Owner owner)
    {
        await repository.AddAsync(owner);
        await repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Owner owner)
    {
        repository.Update(owner);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var owner = await repository.GetByIdAsync(id);

        if (owner is null)
            return;

        repository.Delete(owner);
        await repository.SaveChangesAsync();
    }

    public async Task<Owner?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<List<Owner>> GetAllAsync()
    {
        return (await repository.GetAllAsync()).ToList();
    }
}