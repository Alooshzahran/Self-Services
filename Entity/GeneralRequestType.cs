using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GeneralRequestType : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeNameAR { get; set; }


        public virtual ICollection<GeneralRequest> GeneralRequest { get; set; }

    }
}
