using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositorySalaryInfo : Repository<SalaryInfo>, IRepositorySalaryInfo
    {
        public RepositorySalaryInfo(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
