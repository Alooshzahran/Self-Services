using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string? ThirdName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string ForeignFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string ForeignSecondName { get; set; }
        [StringLength(50)]
        public string? ForeignThirdName { get; set; }
        [Required]
        [StringLength(50)]
        public string ForeignLastName { get; set; }
        [Required]
        [StringLength(50)]
        public string MotherName { get; set; }
        [Required]
        [StringLength(50)]
        public string ForeignMotherName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]

        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
    
        [StringLength(50)]
        public string Mobile { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        public int GenderID { get; set; }
        [Required]
        public int NationalityID { get; set; }
      
        [StringLength(50)]
        public string? PassportNumber { get; set; }
    
        [StringLength(50)]
        public string? SocialSecurityNO { get; set; }
      
        [StringLength(50)]
        public string? NationalNo { get; set; }
        
        [StringLength(50)]
        public string? IqamaNO { get; set; }

        [Required]
        public int MaritalStatusID { get; set; }
        [Required]
        public int? CountryID { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerEmail { get; set; }
        public int? FingerprintNo { get; set; }

        public string? JsonBody { get; set; }
        public string? ERPId { get; set; }

        public int? JobDescriptionID { get; set; }
        public int? GradeID { get; set; }
        public double? Leavebalance { get; set; }


        public virtual Gender? Gender { get; set; }
        public virtual Nationality? Nationality { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public virtual Country? Country { get; set; }
        public virtual JobDescription? JobDescription { get; set; }
        public virtual Grade? Grade { get; set; }


        public virtual ICollection<GeneralRequest> GeneralRequest { get; set; }
        public virtual ICollection<TimeAttendance> TimeAttendance { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }
        public virtual ICollection<SalaryInfo> SalaryInfo { get; set; }
        public virtual ICollection<EmployeeDependent> EmployeeDependent { get; set; }
        public virtual ICollection<EmployeeShiftToEmployee> EmployeeShiftToEmployee { get; set; }
    }
}
