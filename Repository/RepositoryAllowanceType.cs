using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryAllowanceType : Repository<AllowanceType>, IRepositoryAllowanceType
    {
        public RepositoryAllowanceType(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
