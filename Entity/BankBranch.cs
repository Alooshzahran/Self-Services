using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BankBranch : BaseEntity
    {
        public int BankID { get; set; }
        public string BranchName { get; set; }

        public string BranchNameAR { get; set; }

        public virtual Bank? Bank { get; set; }

        public virtual ICollection<SalaryInfo>? SalaryInfo { get; set; }

    }
}
