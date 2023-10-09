using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TimeAttendance : BaseEntity
    {
        public int EmployeeID { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime EntranceTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public int TimeAttendanceStatusID { get; set; }
        public string? Justification { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual TimeAttendanceStatus? TimeAttendanceStatus { get; set; }
    }
}
