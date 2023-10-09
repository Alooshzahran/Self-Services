using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralRequestType : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeNameAR { get; set; }


       // public virtual ICollection<GeneralRequest> GeneralRequest { get; set; }
    }

    public class GeneralRequestTypeValidation : GenericValidator<GeneralRequestType>
    {
        readonly IUnitofwork _UnitOfWork;
        public GeneralRequestTypeValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

            RuleFor(e => e.TypeName).NotNull().WithErrorCode("1011");
            RuleFor(e => e.TypeName).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.TypeNameAR).NotNull().WithErrorCode("1011");
            RuleFor(e => e.TypeNameAR).NotEmpty().WithErrorCode("1012");

        }
    }
}
