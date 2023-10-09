using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Company : BaseEntity
    {
        public string? CompanyNameEN { get; set; }
        public string? CompanyNameAR { get; set; }
        public string? CompanyHeader { get; set; }
        public string? CompanyFooter { get; set; }
        public string? Logo { get; set; }
        public string? BannerImage { get; set; }
        public string? ThemeDarkColor { get; set; }
        public string? ThemeLightColor { get; set; }
    }

    public class CompanyValidation : GenericValidator<Company>
    {
        readonly IUnitofwork _UnitOfWork;
        public CompanyValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

            RuleFor(e => e.CompanyNameEN).NotNull().WithErrorCode("1011");
            RuleFor(e => e.CompanyNameEN).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.CompanyNameAR).NotNull().WithErrorCode("1011");
            RuleFor(e => e.CompanyNameAR).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.Logo).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Logo).NotEmpty().WithErrorCode("1012");

        }
    }
}
