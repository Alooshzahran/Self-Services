using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelfServices.Controllers
{
    public class TimeAttendanceController : Controller
    {
        private readonly IClientContainer _container;
        public TimeAttendanceController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.emps = await _container.Employee.GetAll();
            ViewBag.TimeAttendanceStatus = await _container.TimeAttendanceStatus.GetAll();
            var TimeAttendances = await _container.TimeAttendance.GetAll();
            return View(TimeAttendances);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var employees = await _container.Employee.GetAll();
            ViewBag.AllEmployee = new SelectList(employees, "ID", "ForeignFirstName");
            var TimeAttendanceStatus = await _container.TimeAttendanceStatus.GetAll();
            ViewBag.AllTimeAttendanceStatus = new SelectList(TimeAttendanceStatus, "ID", "Name");
            var TimeAttendance = await _container.TimeAttendance.GetByID(Id);
            return View(TimeAttendance);
        }
        public async Task<IActionResult> Save(DTO.TimeAttendance TimeAttendance)
        {
            Response forcast;
            if (TimeAttendance.ID == 0)
            {
                forcast = await _container.TimeAttendance.Insert(TimeAttendance);
            }
            else
            {
                forcast = await _container.TimeAttendance.Update(TimeAttendance);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "TimeAttendance");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.TimeAttendance TimeAttendance = new DTO.TimeAttendance
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.TimeAttendance.Delete(TimeAttendance);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
