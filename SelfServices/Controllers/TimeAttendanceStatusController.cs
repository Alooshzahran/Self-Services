using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class TimeAttendanceStatusController : Controller
    {
        private readonly IClientContainer _container;
        public TimeAttendanceStatusController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var TimeAttendanceStatuss = await _container.TimeAttendanceStatus.GetAll();
            return View(TimeAttendanceStatuss);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var TimeAttendanceStatus = await _container.TimeAttendanceStatus.GetByID(Id);
            return View(TimeAttendanceStatus);
        }
        public async Task<IActionResult> Save(DTO.TimeAttendanceStatus TimeAttendanceStatus)
        {
            Response forcast;
            if (TimeAttendanceStatus.ID == 0)
            {
                forcast = await _container.TimeAttendanceStatus.Insert(TimeAttendanceStatus);
            }
            else
            {
                forcast = await _container.TimeAttendanceStatus.Update(TimeAttendanceStatus);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "TimeAttendanceStatus");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.TimeAttendanceStatus TimeAttendanceStatus = new DTO.TimeAttendanceStatus
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.TimeAttendanceStatus.Delete(TimeAttendanceStatus);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
