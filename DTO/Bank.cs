using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bank : BaseEntity
    {
        public string BankName { get; set; }
        public string BankNameAR { get; set; }
       // public virtual ICollection<BankBranch>? BankBranch { get; set; }

    }
}
