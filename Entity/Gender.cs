using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
        public virtual ICollection<Employee> Emplooye { get; set; }
    }
    
}
