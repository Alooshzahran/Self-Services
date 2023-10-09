using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MaritalStatus : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        //public virtual ICollection<Employee> Employee { get; set; }

    }
    public class MaritalStatusValidation : GenericValidator<MaritalStatus>
    {
        readonly IUnitofwork _UnitOfWork;
        public MaritalStatusValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

            RuleFor(e => e.Name).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Name).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.NameAR).NotNull().WithErrorCode("1011");
            RuleFor(e => e.NameAR).NotEmpty().WithErrorCode("1012");

        }
    }
}
