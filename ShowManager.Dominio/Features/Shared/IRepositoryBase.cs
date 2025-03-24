

namespace ShowManager.Dominio.Features.Shared;

public interface IRepositoryBase<T> where T : Entidade
{
    Task Adicionar(T entidade, bool saveChanges = false);

    Task<T?> BuscarPorIdAsync(int id);

    Task<int> DeleteAsync(int id);

    Task SaveChangesAsync();
}
