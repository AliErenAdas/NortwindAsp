using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;

namespace Base.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NORTHWNDContext db) : base(db)
        {
        }
        //public override Customer GetById(object id)
        //{
        //    return base.GetById(id.ToString());
        //}
    }
}
