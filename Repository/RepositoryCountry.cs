using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryCountry : Repository<Country>, IRepositoryCountry
    {
        public RepositoryCountry(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
