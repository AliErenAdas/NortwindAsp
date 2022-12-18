using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;

namespace Base.Repositories
{
    public class ShipperRepository : Repository<Shipper>, IShipperRepository
    {
        public ShipperRepository(NORTHWNDContext db) : base(db)
        {
        }
    }
}
