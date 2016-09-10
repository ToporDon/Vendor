using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace vendor.domain.data.abstracts
{
    public interface IRepository<TEntity> :  IDisposable where TEntity : IEntity
    {
        DbSet<TDbSet> Set<TDbSet>() where TDbSet : class;

        EntityEntry<TDbSet> Entry<TDbSet>(TDbSet entity) where TDbSet : class;

        Task<TEntity> GetAsync(long entryId);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filer);

        TEntity Get(Expression<Func<TEntity, bool>> filer);

        Task<long> AddAsync(TEntity entry);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filer);

        Task<long> UpdateAsync(TEntity entry);

        Task<long> PutAsync(TEntity enty);

        Task<long> DeleteAsync(TEntity entry);
    }
}
