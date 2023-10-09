using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Relationship : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameAR { get; set; }
        //public virtual ICollection<EmployeeDependent> EmployeeDependent { get; set; }
        //public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }

    }
    public class RelationshipValidation : GenericValidator<Relationship>
    {
        readonly IUnitofwork _UnitOfWork;
        public RelationshipValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
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
