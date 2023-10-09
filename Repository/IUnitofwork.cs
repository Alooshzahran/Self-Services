using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitofwork : IDisposable
    {
        IRepositoryAllowanceType AllowanceType { get; }
        IRepositoryBank bank { get; }
        IRepositoryBankBranch branch { get; }
        IRepositoryCompany company { get; }
        IRepositoryCountry country { get; }
        IRepositoryEmployee employee { get; }
        IRepositoryEmployeeDependent employeeDependent { get; }
        IRepositoryEmployeeShift employeeShift { get; }
        IRepositoryGender gender { get; }
        IRepositoryGeneralRequest generalRequest { get; }
        IRepositoryGeneralRequestType generalRequestType { get; }
        IRepositoryGrade grade { get; }
        IRepositoryJobDescription jobDescription { get; }
        IRepositoryMaritalStatus maritalStatus { get; }
        IRepositoryNationality National { get; }
        IRepositoryRelationship relationship { get; }
        IRepositorySalaryInfo salaryInfo { get; }
        IRepositoryShiftType shiftType { get; }
        IRepositoryTimeAttendance timeAttendance { get; }
        IRepositoryTimeAttendanceStatus timeAttendanceStatus { get; }
        
        IRepositoryUser user { get; }
        void Complete();
    }
}
