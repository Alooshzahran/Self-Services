using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryMaritalStatus : Repository<MaritalStatus>, IRepositoryMaritalStatus
    {
        public RepositoryMaritalStatus(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
