using System;
using System.Collections.Generic;

namespace SCA.ModuloAdmin.Api.Data.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> FindAll(string[] includes);
        IEnumerable<TEntity> FindAll();
        TEntity FindById(int id);
        TEntity Find(string[] includes, Func<TEntity, bool> where);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
