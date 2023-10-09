using Entity;
using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? ThirdName { get; set; }

        public string? LastName { get; set; }

        public string ForeignFirstName { get; set; }

        public string ForeignSecondName { get; set; }

        public string? ForeignThirdName { get; set; }

        public string ForeignLastName { get; set; }

        public string MotherName { get; set; }

        public string ForeignMotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int? GenderID { get; set; }

        public int? NationalityID { get; set; }


        public string? PassportNumber { get; set; }


        public string? SocialSecurityNO { get; set; }


        public string? NationalNo { get; set; }


        public string? IqamaNO { get; set; }

        public int? MaritalStatusID { get; set; }

        public int? CountryID { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerEmail { get; set; }
        public int? FingerprintNo { get; set; }

        public string? JsonBody { get; set; }
        public string? ERPId { get; set; }

        public int? JobDescriptionID { get; set; }
        public int? GradeID { get; set; }
        public double? Leavebalance { get; set; }

        public MaritalStatus? MaritalStatus { get; set; }
        public Nationality? Nationality { get; set; }
        public Gender? Gender { get; set; }
        public Country? Country { get; set; }
        public JobDescription? JobDescription { get; set; }
        public Grade? Grade { get; set; }
        //public virtual ICollection<EmployeeShiftToEmployee> EmployeeShiftToEmployee { get; set; }


    }

    public class EmployeeValidation : GenericValidator<Employee>
    {
        readonly IUnitofwork _UnitOfWork;
        public EmployeeValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

            RuleFor(e => e.FirstName).NotNull().WithErrorCode("1011");
            RuleFor(e => e.FirstName).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.LastName).NotNull().WithErrorCode("1011");
            RuleFor(e => e.LastName).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.ForeignFirstName).NotNull().WithErrorCode("1011");
            RuleFor(e => e.ForeignFirstName).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.ForeignLastName).NotNull().WithErrorCode("1011");
            RuleFor(e => e.ForeignLastName).NotEmpty().WithErrorCode("1012");

            RuleFor(e => e.DateOfBirth).NotNull().WithErrorCode("1011");
            RuleFor(e => e.DateOfBirth).NotEmpty().WithErrorCode("1012");

            When(e => e.NationalNo != null, () =>
            {
                RuleFor(e => e.NationalNo).Must(UniqueNatNumber).WithErrorCode("1013");
                RuleFor(e => e.NationalNo).Matches(new Regex(@"^([A-Za-z0-9]{1,15})$")).WithErrorCode("1046");
            });

            When(e => e.SocialSecurityNO != null, () =>
            {
                RuleFor(e => e.SocialSecurityNO).Must(UniqueSocialSecurityNO).WithErrorCode("1013");
                RuleFor(e => e.SocialSecurityNO).Matches(new Regex(@"^([A-Za-z0-9]{1,15})$")).WithErrorCode("1046");
            });

            When(e => e.IqamaNO != null, () =>
            {
                RuleFor(e => e.IqamaNO).Must(UniqueIqamaNO).WithErrorCode("1013");
                RuleFor(e => e.IqamaNO).Matches(new Regex(@"^([A-Za-z0-9]{1,15})$")).WithErrorCode("1046");
            });


            When(e => e.PassportNumber != null, () =>
            {
                RuleFor(e => e.PassportNumber).Must(UniquePassportNumber).WithErrorCode("1013");
                RuleFor(e => e.PassportNumber).Matches(new Regex(@"^([A-Za-z0-9]{1,15})$")).WithErrorCode("1046");
            });


            RuleFor(e => e.Email).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Email).NotEmpty().WithErrorCode("1012");

            When(e => e.Email != null, () =>
            {
                RuleFor(e => e.Email).EmailAddress().WithErrorCode("1017");
            });

            RuleFor(e => e.Mobile).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Mobile).NotEmpty().WithErrorCode("1012");
            When(e => !string.IsNullOrEmpty(e.Mobile), () =>
            {
                RuleFor(e => e.Mobile).Matches(new Regex(@"^(\+|00)([0-9]{12})$")).WithErrorCode("1044");
            });

            RuleFor(e => e.Phone).NotNull().WithErrorCode("1011");
            RuleFor(e => e.Phone).NotEmpty().WithErrorCode("1012");
            When(e => !string.IsNullOrEmpty(e.Phone), () =>
            {
                RuleFor(e => e.Phone).Matches(new Regex(@"^(\+|00)([0-9]{12})$")).WithErrorCode("1044");
            });

            RuleFor(e => e.MaritalStatusID).NotNull().WithErrorCode("1011");
            When(e => e.MaritalStatusID != null, () =>
            {
                RuleFor(e => e.MaritalStatusID).Must(IsMaritalStatusIDExist).WithErrorCode("1023");

            });

            RuleFor(e => e.CountryID).NotNull().WithErrorCode("1011");
            When(e => e.CountryID != null, () =>
            {
                RuleFor(e => e.CountryID).Must(IsCountryIDExist).WithErrorCode("1023");
            });

            RuleFor(e => e.GenderID).NotNull().WithErrorCode("1011");
            When(e => e.GenderID != null, () =>
            {
                RuleFor(e => e.GenderID).Must(IsGenderIdExist).WithErrorCode("1023");
            });


            RuleFor(e => e.NationalityID).NotNull().WithErrorCode("1011");
            When(e => e.NationalityID != null, () =>
            {
                RuleFor(e => e.NationalityID).Must(IsNationalityIdExist).WithErrorCode("1023");
            });


            RuleFor(e => e.GradeID).NotNull().WithErrorCode("1011");
            When(e => e.GradeID != null, () =>
            {
                RuleFor(e => e.GradeID).Must(IsGradeIDExist).WithErrorCode("1023");
            });


            //RuleFor(e => e.CountryID).NotNull().WithErrorCode("1011");
            //When(e => e.CountryID != null, () =>
            //{
            //    RuleFor(e => e.CountryID).Must(IsCountryIDExist).WithErrorCode("1023");
            //});


        }


        private bool IsGenderIdExist(int? GenderID)
        {

            return _UnitOfWork.gender.GetByID(GenderID ?? 0) != null;
        }

        private bool IsNationalityIdExist(int? NationalityID)
        {

            return _UnitOfWork.National.GetByID(NationalityID ?? 0) != null;
        }
        private bool IsMaritalStatusIDExist(int? MaritalStatusID)
        {

            return _UnitOfWork.maritalStatus.GetByID(MaritalStatusID ?? 0) != null;
        }
        private bool IsCountryIDExist(int? CountryID)
        {

            return _UnitOfWork.country.GetByID(CountryID ?? 0) != null;
        }
        private bool IsGradeIDExist(int? GradeID)
        {

            return _UnitOfWork.grade.GetByID(GradeID ?? 0) != null;
        }


        private bool UniqueNatNumber(Employee employee, string? NatNumber)
        {
            var x = _UnitOfWork.employee.Find(e => e.NationalNo == NatNumber && employee.ID != e.ID).ToList();
            if (x.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool UniqueSocialSecurityNO(Employee employee, string? SocialSecurityNO)
        {
            var x = _UnitOfWork.employee.Find(e => e.SocialSecurityNO == SocialSecurityNO && employee.ID != e.ID).ToList();
            if (x.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool UniqueIqamaNO(Employee employee, string? IqamaNO)
        {
            var x = _UnitOfWork.employee.Find(e => e.IqamaNO == IqamaNO && employee.ID != e.ID).ToList();
            if (x.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool UniquePassportNumber(Employee employee, string? PassportNumber)
        {
            var x = _UnitOfWork.employee.Find(e => e.PassportNumber == PassportNumber && employee.ID != e.ID).ToList();
            if (x.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

           


        }
    }
}
