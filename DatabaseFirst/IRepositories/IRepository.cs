using DatabaseFirst.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Albüm_Domain.IRepostories
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        T GetById(object id);

      
    }
}
