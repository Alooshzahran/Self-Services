using Entity;
using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeShift : BaseEntity
    {
        public int? EmployeeID { get; set; }
        public int? ShiftTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        //public virtual ICollection<Employee> Employee { get; set; }
        //public virtual ICollection<ShiftType> ShiftType { get; set; }
        //public virtual ICollection<EmployeeShiftToEmployee> EmployeeShiftToEmployee { get; set; }
        //public virtual ICollection<ShiftTypeEmployeeShift> ShiftTypeEmployeeShift { get; set; }

    }
    public class EmployeeShiftValidation : GenericValidator<EmployeeShift>
    {
        readonly IUnitofwork _UnitOfWork;
        public EmployeeShiftValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
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
                        RuleFor(e => e.ShiftTypeID).NotNull().WithErrorCode("1011");
                        When(e => e.ShiftTypeID != null, () =>
                        {
                            RuleFor(e => e.ShiftTypeID).Must(IsShiftTypeIDExist).WithErrorCode("1023");
                        });
                    });





                    RuleFor(e => e.FromDate).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.FromDate).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.ToDate).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.ToDate).NotEmpty().WithErrorCode("1012");

              

                });


            });

        }




        private bool IsShiftTypeIDExist(int? BankID)
        {
            return _UnitOfWork.employeeShift.GetByID(BankID ?? 0) != null;
        }
        private bool IsEmployeeIDExist(int? EmployeeID)
        {
            return _UnitOfWork.employee.GetByID(EmployeeID ?? 0) != null;
        }

    }

}
