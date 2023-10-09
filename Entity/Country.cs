using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public string CountryNameAR { get; set; }
        public string CountryCode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
