using Connecter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public interface IClientContainer
    {
        ServiceSetting ServiceSetting { get; }
        IClient<DTO.AllowanceType> AllowanceType { get; }
        IClient<DTO.Bank> Bank { get; }
        IClient<DTO.BankBranch> BankBranch { get; }
        IClient<DTO.Company> Company { get; }
        IClient<DTO.Country> Country { get; }
        IClient<DTO.Employee> Employee { get; }
        IClient<DTO.EmployeeDependent> EmployeeDependent { get; }
        IClient<DTO.EmployeeShift> EmployeeShift { get; }
        IClient<DTO.Gender> Gender { get; }
        IClient<DTO.GeneralRequest> GeneralRequest { get; }
        IClient<DTO.GeneralRequestType> GeneralRequestType { get; }
        IClient<DTO.Grade> Grade { get; }
        IClient<DTO.JobDescription> JobDescription { get; }
        IClient<DTO.MaritalStatus> MaritalStatus { get; }
        IClient<DTO.Nationality> Nationality { get; }
        IClient<DTO.Relationship> Relationship { get; }
        IClient<DTO.SalaryInfo> SalaryInfo { get; }
        IClient<DTO.ShiftType> ShiftType { get; }
        IClient<DTO.TimeAttendance> TimeAttendance { get; }
        IClient<DTO.TimeAttendanceStatus> TimeAttendanceStatus { get; }
        IClient<DTO.User> User { get; }
    }
}
