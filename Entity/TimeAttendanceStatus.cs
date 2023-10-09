using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TimeAttendanceStatus : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
        public virtual ICollection<TimeAttendance> TimeAttendance { get; set; }
    }
}
