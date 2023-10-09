using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Country : BaseEntity
    {
        public string? CountryName { get; set; }
        public string? CountryNameAR { get; set; }
        public string? CountryCode { get; set; }
       // public virtual ICollection<Employee> Employee { get; set; }

    }
    public class CountryValidation : GenericValidator<Country>
    {
        readonly IUnitofwork _UnitOfWork;
        public CountryValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)

        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == 0 || e.ID == null) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                RuleFor(e => e.CountryName).NotNull().WithErrorCode("1011");
                RuleFor(e => e.CountryName).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.CountryNameAR).NotNull().WithErrorCode("1011");
                RuleFor(e => e.CountryNameAR).NotEmpty().WithErrorCode("1012");
                RuleFor(e => e.CountryCode).NotNull().WithErrorCode("1011");
                RuleFor(e => e.CountryCode).NotEmpty().WithErrorCode("1012");
            });
        }
    }
}
