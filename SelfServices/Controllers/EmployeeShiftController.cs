using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelfServices.Controllers
{
    public class EmployeeShiftController : Controller
    {
        private readonly IClientContainer _container;
        public EmployeeShiftController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var EmployeeShifts = await _container.EmployeeShift.GetAll();
            return View(EmployeeShifts);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var employees = await _container.Employee.GetAll();
            var shifttype = await _container.ShiftType.GetAll();
            ViewBag.AllEmployee = new SelectList(employees, "ID", "ForeignFirstName");
            ViewBag.AllShiftType = new SelectList(shifttype, "ID", "ShiftTypeName");
            
            var EmployeeShift = await _container.EmployeeShift.GetByID(Id);
            return View(EmployeeShift);
        }
        public async Task<IActionResult> Save(DTO.EmployeeShift EmployeeShift)
        {
            Response forcast;
            if (EmployeeShift.ID == 0)
            {
                forcast = await _container.EmployeeShift.Insert(EmployeeShift);
            }
            else
            {
                forcast = await _container.EmployeeShift.Update(EmployeeShift);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "EmployeeShift");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.EmployeeShift EmployeeShift = new DTO.EmployeeShift
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.EmployeeShift.Delete(EmployeeShift);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
