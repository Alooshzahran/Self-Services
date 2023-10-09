using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryCompany : Repository<Company>, IRepositoryCompany
    {
        public RepositoryCompany(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
