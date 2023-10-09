using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AllowanceType : BaseEntity
    {
        public string? AllowanceTypeName { get; set; }

        public string?  AllowanceTypeNameAR { get; set; }

        public bool? IsActive { get; set; }
    }


    public class AllowanceTypeValidation : GenericValidator<AllowanceType>
    {
        readonly IUnitofwork _UnitOfWork;
        public AllowanceTypeValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == 0 || e.ID == null) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.IsActive).NotNull().WithErrorCode("1011");
                RuleFor(e => e.AllowanceTypeName).NotNull().WithErrorCode("1011");
                RuleFor(e => e.AllowanceTypeName).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.AllowanceTypeNameAR).NotNull().WithErrorCode("1011");
                RuleFor(e => e.AllowanceTypeNameAR).NotEmpty().WithErrorCode("1012");
            });
        }
    }
}

