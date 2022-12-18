using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;

namespace Base.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NORTHWNDContext db) : base(db)
        {
        }
    }
}
