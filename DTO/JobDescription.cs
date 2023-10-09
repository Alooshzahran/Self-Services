using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JobDescription : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameAR{ get; set; }
        public string? Description { get; set; }
        //public virtual ICollection<Employee> Employee { get; set; }

    }

    public class JobDescriptionValidation : GenericValidator<JobDescription>
    {
        readonly IUnitofwork _UnitOfWork;
        public JobDescriptionValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

            RuleFor(e => e.Name).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Name).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.NameAR).NotNull().WithErrorCode("1011");
            RuleFor(e => e.NameAR).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.Description).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Description).NotEmpty().WithErrorCode("1012");

        }
    }
}
