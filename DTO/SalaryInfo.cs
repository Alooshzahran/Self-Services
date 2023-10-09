using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SalaryInfo : BaseEntity
    {
        public int? EmployeeID { get; set; }
        public double? BasicSalary { get; set; }
        public int? BankID { get; set; }
        public int? BankBranchID { get; set; }
        public string? BankAccountNo { get; set; }
        public bool? IsCurrent { get; set; }
        public string? BankSwift { get; set; }
        public  Employee? Employee { get; set; }
        public  BankBranch? BankBranch { get; set; }


    }

    public class SalaryInfoValidation : GenericValidator<SalaryInfo>
    {
        readonly IUnitofwork _UnitOfWork;
        public SalaryInfoValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == null || e.ID == 0) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                When(e => e.ID == null || e.ID > 0, () =>
                {
                    RuleFor(e => e.EmployeeID).NotNull().WithErrorCode("1011");
                    When(e => e.EmployeeID != null, () =>
                    {
                        RuleFor(e => e.EmployeeID).Must(IsEmployeeIDExist).WithErrorCode("1023");
                    });
                });

                When(e => (e.ID == null || e.ID == 0) || (e.ID > 0 && !e.IsDeleted), () =>
                {
                    When(e => e.ID == null || e.ID > 0, () =>
                    {
                        RuleFor(e => e.BankID).NotNull().WithErrorCode("1011");
                        When(e => e.BankID != null, () =>
                        {
                            RuleFor(e => e.BankID).Must(IsBankIDExist).WithErrorCode("1023");
                        });
                    });

                    When(e => (e.ID == null || e.ID == 0) || (e.ID > 0 && !e.IsDeleted), () =>
                    {
                        When(e => e.ID == null || e.ID > 0, () =>
                        {
                            RuleFor(e => e.BankBranchID).NotNull().WithErrorCode("1011");
                            When(e => e.BankBranchID != null, () =>
                            {
                                RuleFor(e => e.BankBranchID).Must(IsBankBranchIDExist).WithErrorCode("1023");
                            });
                        });

                        RuleFor(e => e.IsCurrent).NotNull().WithErrorCode("1011");

                        RuleFor(e => e.BankSwift).NotNull().WithErrorCode("1011");
                        RuleFor(e => e.BankSwift).NotEmpty().WithErrorCode("1012");

                        RuleFor(e => e.BankAccountNo).NotNull().WithErrorCode("1011");
                        RuleFor(e => e.BankAccountNo).NotEmpty().WithErrorCode("1012");

                        RuleFor(e => e.BasicSalary).NotNull().WithErrorCode("1011");
                        RuleFor(e => e.BasicSalary).NotEmpty().WithErrorCode("1012");


                    });


                });
            });
             
        }

        private bool IsBankIDExist(int? BankID)
        {
            return _UnitOfWork.bank.GetByID(BankID ?? 0) != null;
        }
        private bool IsEmployeeIDExist(int? EmployeeID)
        {
            return _UnitOfWork.employee.GetByID(EmployeeID ?? 0) != null;
        }

        private bool IsBankBranchIDExist(int? BankBranchID)
        {
            return _UnitOfWork.branch.GetByID(BankBranchID ?? 0) != null;
        }
    }
}
