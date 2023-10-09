using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SalaryInfo : BaseEntity
    {
        public int EmployeeID { get; set; }
        public double BasicSalary { get; set; }
        public int BankID { get; set; }
        public int BankBranchID{ get; set; }
        public string BankAccountNo { get; set; }
        public bool IsCurrent { get; set; }
        public string BankSwift { get; set; }
        public virtual Employee? Employee { get; set; }
        
        public virtual BankBranch? BankBranch { get; set; }

    }
}
