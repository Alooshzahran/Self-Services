using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDependent : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameAR { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? RelationshipID { get; set; }
        public int? EmployeeID { get; set; }
        public  Employee? Employee { get; set; }
        public  Relationship? Relationship { get; set; }

    }
    public class EmployeeDependentValidation : GenericValidator<EmployeeDependent>
    {
        readonly IUnitofwork _UnitOfWork;
        public EmployeeDependentValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
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
                        RuleFor(e => e.RelationshipID).NotNull().WithErrorCode("1011");
                        When(e => e.RelationshipID != null, () =>
                        {
                            RuleFor(e => e.RelationshipID).Must(IsRelationshipIDExist).WithErrorCode("1023");
                        });
                    });



                   

                    RuleFor(e => e.Name).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.Name).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.NameAR).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.NameAR).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.BirthDate).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.BirthDate).NotEmpty().WithErrorCode("1012");


                });


            });
       
        }

     


        private bool IsRelationshipIDExist(int? BankID)
        {
            return _UnitOfWork.relationship.GetByID(BankID ?? 0) != null;
        }
        private bool IsEmployeeIDExist(int? EmployeeID)
        {
            return _UnitOfWork.employee.GetByID(EmployeeID ?? 0) != null;
        }

    }  
    
}
