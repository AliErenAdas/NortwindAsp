using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;

namespace Base.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(NORTHWNDContext db) : base(db)
        {
        }
    }
}
