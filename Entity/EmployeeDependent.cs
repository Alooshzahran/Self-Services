using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EmployeeDependent : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
        public DateTime BirthDate { get; set; }
        public int RelationshipID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Relationship? Relationship { get; set; }

    }
}
