using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAquisicao.Api.Data.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> FindAll(string[] includes);
        IEnumerable<TEntity> FindAll();
        TEntity FindById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
