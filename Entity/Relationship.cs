using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Relationship : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
        public virtual ICollection<EmployeeDependent> EmployeeDependent { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }
    }
}
