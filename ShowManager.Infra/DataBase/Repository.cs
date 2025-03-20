using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Shared;
using ShowManager.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Infra.DataBase.Repository;

public class Repository<T> : IRepository<T> where T : Entidade
{
    protected DbSet<T> Query { get; set; }
    protected DbContext Context { get; set; }

    public Repository(ShowManagerContext context)
    {
        this.Context = context;
        this.Query = Context.Set<T>();
    }

    public async Task<T> SaveAsync(T entity)
    {
        var obj = await this.Query.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
        if (obj != null)
        {
            this.Context.Entry(obj).CurrentValues.SetValues(entity);
        }
        else
        {
            await this.Query.AddAsync(entity);
        }
        await this.Context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var obj = await this.Query.FindAsync(id);
        if (obj != null)
        {
            this.Query.Remove(obj);
            await this.Context.SaveChangesAsync();
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await this.Query.FindAsync(id);
    }

    public async Task<IEnumerable<T>?> GetByIdsAsync(List<int> ids)
    {
        return await this.Query.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await this.Query.ToListAsync();
    }

    public async Task<IEnumerable<T>?> FindAllByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Query.Where(expression).ToListAsync();
    }

    public async Task<T?> FindOneByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Query.Where(expression).FirstOrDefaultAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Query.AnyAsync(expression);
    }
}
