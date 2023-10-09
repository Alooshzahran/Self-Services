using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GeneralRequest : BaseEntity
    {
        public int GeneralRequestTypeID { get; set; }
        public string Note { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual GeneralRequestType? GeneralRequestType { get; set; }

    }
}
