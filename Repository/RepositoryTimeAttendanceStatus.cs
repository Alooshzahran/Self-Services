using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryTimeAttendanceStatus : Repository<TimeAttendanceStatus>, IRepositoryTimeAttendanceStatus
    {
        public RepositoryTimeAttendanceStatus(MyDBContext dbContext) : base(dbContext)
        {

        }
    }
}
