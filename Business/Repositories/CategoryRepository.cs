using DatabaseFirst.IRepositories;
using DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(NORTHWNDContext db) : base(db)
        {
        }
    }
}
