
using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Shared;
using ShowManager.Infra.Context;

namespace ShowManager.Infra.DataBase;

public class RepositoryBase<T>(ShowManagerContext context) : IRepositoryBase<T> where T : Entidade
{
    public async Task Adicionar(T entidade, bool saveChanges = false)
    {
        await context.Set<T>().AddAsync(entidade);

        if (saveChanges)
            await SaveChangesAsync();
    }

    public async Task<T?> BuscarPorIdAsync(int id)
    {
        return await context.Set<T>().SingleOrDefaultAsync(s => s.Id == id);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await context.Set<T>().Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
