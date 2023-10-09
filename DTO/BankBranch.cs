using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BankBranch : BaseEntity
    {
        public int? BankID { get; set; }
        public string? BranchName { get; set; }

        public string? BranchNameAR { get; set; }

        public  Bank? Bank { get; set; }


               
    }
}
