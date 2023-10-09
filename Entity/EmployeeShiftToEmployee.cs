using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmployeeShiftToEmployee 
    {
        public int EmployeeId { get; set; }
        public int EmployeeShiftId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual EmployeeShift? EmployeeShift { get; set; }
    }
}
