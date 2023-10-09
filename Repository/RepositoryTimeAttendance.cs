using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryTimeAttendance : Repository<TimeAttendance>, IRepositoryTimeAttendance
    {
        public RepositoryTimeAttendance(MyDBContext dbContext) : base(dbContext)
        {

        }

        public TimeAttendance GetTimeAttendanceWhereEmpId(int Id)
        {
           var timeatten =  _dbContext.TimeAttendance.FirstOrDefault(e =>e.EmployeeID == Id);
            return timeatten;
        }
    }
}
