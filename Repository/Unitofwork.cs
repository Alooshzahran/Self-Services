using Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Repository
{
    public class Unitofwork : IUnitofwork
    {
        private readonly MyDBContext _context;
      

        public IRepositoryAllowanceType AllowanceType { get; private set; }
        public IRepositoryBank bank { get; private set; }
        public IRepositoryBankBranch branch { get; private set; }
        public IRepositoryCompany company { get; private set; }
        public IRepositoryCountry country { get; private set; }
        public IRepositoryEmployee employee { get; private set; }
        public IRepositoryEmployeeDependent employeeDependent { get; private set; }

        public IRepositoryEmployeeShift employeeShift { get; private set; }

        public IRepositoryGender gender { get; private set; }

        public IRepositoryGeneralRequest generalRequest { get; private set; }

        public IRepositoryGeneralRequestType generalRequestType { get; private set; }

        public IRepositoryGrade grade { get; private set; }

        public IRepositoryJobDescription jobDescription { get; private set; }

        public IRepositoryMaritalStatus maritalStatus { get; private set; }

        public IRepositoryNationality National { get; private set; }

        public IRepositoryRelationship relationship { get; private set; }

        public IRepositorySalaryInfo salaryInfo { get; private set; }

        public IRepositoryShiftType shiftType { get; private set; }

        public IRepositoryTimeAttendance timeAttendance { get; private set; }

    public IRepositoryTimeAttendanceStatus timeAttendanceStatus { get; private set; }

    public IRepositoryUser user { get; private set; }
        public Unitofwork(MyDBContext context)
        {
            _context = context;
            AllowanceType = new RepositoryAllowanceType(context);
            bank = new RepositoryBank(context);
            branch = new RepositoryBankBranch(context);
            company = new RepositoryCompany(context);
            country = new RepositoryCountry(context);
            employee = new RepositoryEmployee(context);
            employeeDependent = new RepositoryEmployeeDependent(context);
            employeeShift = new RepositoryEmployeeShift(context);
            gender = new RepositoryGender(context);
            generalRequest = new RepositoryGeneralRequest(context);
            generalRequestType = new RepositoryGeneralRequestType(context);
            grade = new RepositoryGrade(context);
            jobDescription = new RepositoryJobDescription(context);
            maritalStatus = new RepositoryMaritalStatus(context);
            National = new RepositoryNationality(context);
            relationship = new RepositoryRelationship(context);
            salaryInfo = new RepositorySalaryInfo(context);
            shiftType = new RepositoryShiftType(context);
            timeAttendance = new RepositoryTimeAttendance(context);
            timeAttendanceStatus = new RepositoryTimeAttendanceStatus(context);
            user = new RepositoryUser(context);


        }
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}