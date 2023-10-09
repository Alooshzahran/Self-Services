using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TimeAttendance : BaseEntity
    {
        public int? EmployeeID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? EntranceTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        public int? TimeAttendanceStatusID { get; set; }
        public string? Justification { get; set; }

        public  Employee? Employee { get; set; }
        public  TimeAttendanceStatus? TimeAttendanceStatus { get; set; }

    }
    public class TimeAttendanceValidation : GenericValidator<TimeAttendance>
    {
        readonly IUnitofwork _UnitOfWork;
        public TimeAttendanceValidation(IUnitofwork UnitOfWork) : base(UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            When(e => (e.ID == null || e.ID == 0) || (e.ID > 0 && !e.IsDeleted), () =>
            {
                When(e => e.ID == null || e.ID > 0, () =>
                {
                    RuleFor(e => e.EmployeeID).NotNull().WithErrorCode("1011");
                    When(e => e.EmployeeID != null, () =>
                    {
                        RuleFor(e => e.EmployeeID).Must(IsEmployeeIDExist).WithErrorCode("1023");
                    });
                });

                When(e => (e.ID == null || e.ID == 0) || (e.ID > 0 && !e.IsDeleted), () =>
                {
                    When(e => e.ID == null || e.ID > 0, () =>
                    {
                        RuleFor(e => e.TimeAttendanceStatusID).NotNull().WithErrorCode("1011");
                        When(e => e.TimeAttendanceStatusID != null, () =>
                        {
                            RuleFor(e => e.TimeAttendanceStatusID).Must(IsTimeAttendanceStatusIDExist).WithErrorCode("1023");
                        });
                    });





                    RuleFor(e => e.TransactionDate).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.TransactionDate).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.EntranceTime).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.EntranceTime).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.LeaveTime).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.LeaveTime).NotEmpty().WithErrorCode("1012");

                    RuleFor(e => e.Justification).NotNull().WithErrorCode("1011");
                    RuleFor(e => e.Justification).NotEmpty().WithErrorCode("1012");


                });


            });

        }




        private bool IsTimeAttendanceStatusIDExist(int? BankID)
        {
            return _UnitOfWork.timeAttendanceStatus.GetByID(BankID ?? 0) != null;
        }
        private bool IsEmployeeIDExist(int? EmployeeID)
        {
            return _UnitOfWork.employee.GetByID(EmployeeID ?? 0) != null;
        }

    }

}

