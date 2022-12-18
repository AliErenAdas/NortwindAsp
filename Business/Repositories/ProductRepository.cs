using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;

namespace Base.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NORTHWNDContext db) : base(db)
        {
        }
    }
}
