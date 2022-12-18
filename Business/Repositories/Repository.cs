using Albüm_Domain.IRepostories;
using DatabaseFirst.Abstract;
using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private static NORTHWNDContext _db;
        private static DbSet<T> _dbSet;

        public Repository(NORTHWNDContext db)
        {
            if (_db == null)
            {
                _db = new NORTHWNDContext();
            }
            _dbSet = _db.Set<T>();
        }

        public void Create(T entity)
        {
            if (!_dbSet.Contains(entity))
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Veri Silinemedi");
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            //using (var context = new NORTHWNDContext())
            //{
                try
                {
                    //var updatedEntity = context.Entry(entity);
                    //updatedEntity.State = EntityState.Modified;
                    //context.SaveChanges();
                    
                    //_db.ChangeTracker.Clear();
                    
                    _db.Entry(entity).State = EntityState.Modified;
                    //_dbSet.Attach(entity);
                    _db.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception("Veri güncellenemedi");
                }
            //}
               

        }
    }
}
