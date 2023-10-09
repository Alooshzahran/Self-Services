using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryShiftType : Repository<ShiftType>, IRepositoryShiftType
    {
        public RepositoryShiftType(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
    
}
