using Connecter.Client;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IClientContainer _client;
        private readonly IClientTimeAttendance _clientTime;
        public AttendeesController(IClientContainer client, IClientTimeAttendance clientTime)
        {
            _client = client;
            _clientTime = clientTime;
        }
        
        public async Task<IActionResult> Index()
        {
            System.Globalization.CultureInfo ci =
            System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek today = DateTime.Now.DayOfWeek;
            DateTime sow = DateTime.Now.AddDays(-(today - fdow)).Date;
            ViewBag.Sun = sow;
     
            var atten = await _client.TimeAttendance.GetAll();
            return View(atten);
        }
        public async Task<IActionResult> MyTeam()
        {
            var Emps = await _client.Employee.GetAll();
            return View(Emps);
        }
        public async Task<IActionResult> MemberAttendance(int Id)
        {
            var atten = await _clientTime.GetTimeAttendance(Id);
            return View(atten);
        }
        public async Task<IActionResult> MemberInformation(int Id)
        {
            var Emp = await _client.Employee.GetByID(Id);
            return View(Emp);
        }
        public async Task<IActionResult> AttendeesPlanner()
        {
            var Empshift = await _client.EmployeeShift.GetAll();
            return View(Empshift);
        }

    }
}
