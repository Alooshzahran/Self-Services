using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Grade : BaseEntity
    {
        public string Name { get; set; }
        public string NameAR { get; set; }
       // public virtual ICollection<Employee> Employee { get; set; }
    }

    public class GradeValidation : GenericValidator<Grade>
    {
        readonly IUnitofwork _UnitOfWork;
        public GradeValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == 0 || e.ID == null) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.Name).NotNull().WithErrorCode("1011");
                RuleFor(e => e.Name).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.NameAR).NotNull().WithErrorCode("1011");
                RuleFor(e => e.NameAR).NotEmpty().WithErrorCode("1012");
            });
        }
    }
}
