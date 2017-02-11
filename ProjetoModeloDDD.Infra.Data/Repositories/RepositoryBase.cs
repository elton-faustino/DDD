using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositorires;
using ProjetoModeloDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        public ProjetoModeloContext db = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
            //Unit of Work - modificar várias classes ao mesmo tempo em transação única
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            //return db.Set<TEntity>().AsNoTracking().ToList();
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();

        }

        public void Dispose()
        {
            
        }
    }
}
