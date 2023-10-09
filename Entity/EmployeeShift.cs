using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmployeeShift : BaseEntity
    {
        public int EmployeeID { get; set; }
        public int ShiftTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<ShiftType> ShiftType { get; set; }
        public virtual ICollection<EmployeeShiftToEmployee> EmployeeShiftToEmployee { get; set; }
        public virtual ICollection<ShiftTypeEmployeeShift> ShiftTypeEmployeeShift { get; set; }



    }
}
