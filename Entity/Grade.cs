using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Grade : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
