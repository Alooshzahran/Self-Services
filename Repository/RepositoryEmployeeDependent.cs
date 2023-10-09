using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryEmployeeDependent : Repository<EmployeeDependent>, IRepositoryEmployeeDependent
    {
        public RepositoryEmployeeDependent(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
