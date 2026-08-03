using IceCity.EFCore.Entities;

using IceCity.EFCore2.Repositories.Interfaces;

namespace IceCity.EFCore.Services;

public class HouseService
{
    private readonly IHouseRepository repository;

    public HouseService(IHouseRepository repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(House house)
    {
        await repository.AddAsync(house);
        await repository.SaveChangesAsync();
    }

    public async Task<List<House>> GetAllAsync()
    {
        return (await repository.GetAllAsync()).ToList();
    }

    public async Task<House?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(House house)
    {
        repository.Update(house);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var house = await repository.GetByIdAsync(id);

        if (house is null)
            return;

        repository.Delete(house);
        await repository.SaveChangesAsync();
    }
}