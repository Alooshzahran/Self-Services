using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralRequest : BaseEntity
    {
        public int? GeneralRequestTypeID { get; set; }
        public string? Note { get; set; }
        public int? EmployeeID { get; set; }
        public  Employee? Employee { get; set; }
        public  GeneralRequestType? GeneralRequestType { get; set; }
    
    }

    public class GeneralRequestValidation : GenericValidator<GeneralRequest>
    {
        readonly IUnitofwork _UnitOfWork;
        public GeneralRequestValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
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
                        RuleFor(e => e.GeneralRequestTypeID).NotNull().WithErrorCode("1011");
                        When(e => e.GeneralRequestTypeID != null, () =>
                        {
                            RuleFor(e => e.GeneralRequestTypeID).Must(IsGeneralRequestTypeIDExist).WithErrorCode("1023");
                        });
                    });
                    RuleFor(e => e.Note).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.Note).NotEmpty().WithErrorCode("1012");
                });



            });

        }

        private bool IsGeneralRequestTypeIDExist(int? GeneralRequestTypeID)
        {
            return _UnitOfWork.generalRequest.GetByID(GeneralRequestTypeID ?? 0) != null;
        }
        private bool IsEmployeeIDExist(int? EmployeeID)
        {
            return _UnitOfWork.employee.GetByID(EmployeeID ?? 0) != null;
        }

       
    }
}

