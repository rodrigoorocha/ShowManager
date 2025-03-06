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

public class Repository<T> : IRepository<T> where T : class
{
    protected DbSet<T> Query { get; set; }
    protected DbContext Context { get; set; }

    public Repository(ShowManagerContext context)
    {
        this.Context = context;
        this.Query = Context.Set<T>();
    }


    public async Task DeleteAsync(int id)
    {
        var entity = await Query.FindAsync(id);
        Query.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var query = await Query.FindAsync(id);
        return query;

    }

    public async Task<IEnumerable<T>> GetByIdsAsync(List<int> ids)
    {

        List<T> entities = new List<T>();

        foreach (int id in ids)
        {
            var entity = await Query.FindAsync(id);

            if (entity != null)
            {
                entities.Add(entity);
            }
        }

        return entities;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await this.Query.ToListAsync();
    }

    public async Task SaveAsync(T entity)
    {
        await this.Query.AddAsync(entity);
        await this.Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        this.Query.Update(entity);
        await this.Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAllByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Query.Where(expression).ToListAsync();
    }

    public async Task<T> FindOneByCriterioAsync(Expression<Func<T, bool>> expression)
    {
        return await this.Query.FirstOrDefaultAsync(expression);
    }
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await Query.AnyAsync(expression);
    }
}
