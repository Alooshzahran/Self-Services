using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AllowanceType : BaseEntity

    {
        public string AllowanceTypeName { get; set; }

        public string AllowanceTypeNameAr { get; set; }

        public bool IsActive { get; set; }

       // public virtual ICollection<Allowance> Allowance { get; set; }
    }
}
