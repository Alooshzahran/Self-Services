using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryEmployeeShift : Repository<EmployeeShift>, IRepositoryEmployeeShift
    {
        public RepositoryEmployeeShift(MyDBContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<EmployeeShift> GetByTime(DateTime From)
        {
            return _dbContext.EmployeeShift.Where(e => e.FromDate == From);
        }
    }
}
