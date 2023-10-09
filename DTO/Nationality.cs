using FluentValidation;
using Repository;

namespace DTO
{
    public class Nationality : BaseEntity
    {

        public string? Name { get; set; }
        public string? NameAR { get; set; }
        public bool? IsRequiredNationalNo { get; set; }

        public bool? IsAllowedSocialSecurityNo { get; set; }

        public bool? IsPassportNumber { get; set; }

        public bool? IsIqamaNO { get; set; }
        public bool? IsDefault { get; set; }
        //public virtual ICollection<Employee> Employee { get; set; }
    }
    public class EmployeeNationalityValidation : GenericValidator<Nationality>
    {
        readonly IUnitofwork _UnitOfWork;
        public EmployeeNationalityValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == 0 || e.ID == null) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.Name).NotNull().WithErrorCode("1011");
                RuleFor(e => e.Name).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.NameAR).NotNull().WithErrorCode("1011");
                RuleFor(e => e.NameAR).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.IsAllowedSocialSecurityNo).NotNull().WithErrorCode("1011");
                RuleFor(e => e.IsRequiredNationalNo).NotNull().WithErrorCode("1011");
                RuleFor(e => e.IsPassportNumber).NotNull().WithErrorCode("1011");
                RuleFor(e => e.IsIqamaNO).NotNull().WithErrorCode("1011");
                RuleFor(e => e.IsDefault).NotNull().WithErrorCode("1011");
            });
        }
    }
}
