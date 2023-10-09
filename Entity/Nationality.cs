using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Nationality : BaseEntity
    {

        public string Name { get; set; }
        public string NameAR { get; set; }
        public bool IsRequiredNationalNo { get; set; }

        public bool IsAllowedSocialSecurityNo { get; set; }

        public bool IsPassportNumber { get; set; }

        public bool IsIqamaNO { get; set; }
        public bool IsDefault { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }


    }
}
