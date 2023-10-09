using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryEmployee : Repository<Employee>, IRepositoryEmployee
    {
        public RepositoryEmployee(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
