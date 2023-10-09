using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ShiftTypeEmployeeShift
    {
        public int ShiftTypeId { get; set; }
        public int EmployeeShiftId { get; set; }
        public virtual ShiftType? ShiftType { get; set; }
        public virtual EmployeeShift? EmployeeShift { get; set; }
    }
}
