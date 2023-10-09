using Connecter.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecter.Client
{
    public class ClientContainer : IClientContainer
    {
        public ServiceSetting ServiceSetting { get; private set; }

       public IClient<AllowanceType> AllowanceType { get; private set; }

        public IClient<Bank> Bank { get; private set; }

        public IClient<BankBranch> BankBranch { get; private set; }

        public IClient<Company> Company { get; private set; }

        public IClient<Country> Country { get; private set; }

        public IClient<Employee> Employee { get; private set; }

        public IClient<EmployeeDependent> EmployeeDependent  { get; private set; }

        public IClient<EmployeeShift> EmployeeShift  { get; private set; }

        public IClient<Gender> Gender  { get; private set; }

        public IClient<GeneralRequest> GeneralRequest { get; private set; }

        public IClient<GeneralRequestType> GeneralRequestType  { get; private set; }

        public IClient<Grade> Grade  { get; private set; }

        public IClient<JobDescription> JobDescription  { get; private set; }

        public IClient<MaritalStatus> MaritalStatus  { get; private set; }

        public IClient<Nationality> Nationality  { get; private set; }

        public IClient<Relationship> Relationship  { get; private set; }

        public IClient<SalaryInfo> SalaryInfo  { get; private set; }

        public IClient<ShiftType> ShiftType  { get; private set; }

        public IClient<TimeAttendance> TimeAttendance  { get; private set; }

        public IClient<TimeAttendanceStatus> TimeAttendanceStatus  { get; private set; }

        public IClient<User> User  { get; private set; }

        public ClientContainer(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext)
        {
            ServiceSetting = serviceSetting.Value;
            AllowanceType = new Client<AllowanceType>(httpClient,serviceSetting,httpContext);
            Bank = new Client<Bank>(httpClient,serviceSetting,httpContext);
            BankBranch = new Client<BankBranch>(httpClient,serviceSetting,httpContext);
            Company = new Client<Company>(httpClient,serviceSetting,httpContext);
            Country = new Client<Country>(httpClient,serviceSetting,httpContext);
            Employee = new Client<Employee>(httpClient,serviceSetting,httpContext);
            EmployeeDependent = new Client<EmployeeDependent>(httpClient,serviceSetting,httpContext);
            EmployeeShift = new Client<EmployeeShift>(httpClient,serviceSetting,httpContext);
            Gender = new Client<Gender>(httpClient,serviceSetting,httpContext);
            GeneralRequest = new Client<GeneralRequest>(httpClient,serviceSetting,httpContext);
            GeneralRequestType = new Client<GeneralRequestType>(httpClient,serviceSetting,httpContext);
            Grade = new Client<Grade>(httpClient,serviceSetting,httpContext);
            JobDescription = new Client<JobDescription>(httpClient,serviceSetting,httpContext);
            MaritalStatus = new Client<MaritalStatus>(httpClient,serviceSetting,httpContext);
            Nationality = new Client<Nationality>(httpClient,serviceSetting,httpContext);
            Relationship = new Client<Relationship>(httpClient,serviceSetting,httpContext);
            SalaryInfo = new Client<SalaryInfo>(httpClient,serviceSetting,httpContext);
            ShiftType = new Client<ShiftType>(httpClient,serviceSetting,httpContext);
            TimeAttendance = new Client<TimeAttendance>(httpClient,serviceSetting,httpContext);
            TimeAttendanceStatus = new Client<TimeAttendanceStatus>(httpClient,serviceSetting,httpContext);
            User = new Client<User>(httpClient,serviceSetting,httpContext);
        }
    }
}