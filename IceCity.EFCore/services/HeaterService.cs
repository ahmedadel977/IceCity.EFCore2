using IceCity.EFCore.Entities;
using IceCity.EFCore2.Repositories.Interfaces;

namespace IceCity.EFCore.Services;

public class HeaterService
{
    private readonly IHeaterRepository repository;

    public HeaterService(IHeaterRepository repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(Heater heater)
    {
        await repository.AddAsync(heater);
        await repository.SaveChangesAsync();
    }

    public async Task<List<Heater>> GetAllAsync()
    {
        return (await repository.GetAllAsync()).ToList();
    }

    public async Task<Heater?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Heater heater)
    {
        repository.Update(heater);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var heater = await repository.GetByIdAsync(id);

        if (heater is null)
            return;

        repository.Delete(heater);
        await repository.SaveChangesAsync();
    }
}