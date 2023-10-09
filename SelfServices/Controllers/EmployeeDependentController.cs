using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelfServices.Controllers
{
    public class EmployeeDependentController : Controller
    {
        private readonly IClientContainer _container;
        public EmployeeDependentController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.emps = await _container.Employee.GetAll();
            ViewBag.relations = await _container.Relationship.GetAll();
            var EmployeeDependents = await _container.EmployeeDependent.GetAll();
            return View(EmployeeDependents);

        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var employees = await _container.Employee.GetAll();
            var relations = await _container.Relationship.GetAll();
            ViewBag.AllEmployee = new SelectList(employees, "ID", "ForeignFirstName");
            ViewBag.AllRelationship = new SelectList(relations, "ID", "Name");
           var EmployeeDependent = await _container.EmployeeDependent.GetByID(Id);
            return View(EmployeeDependent);
        }
        public async Task<IActionResult> Save(DTO.EmployeeDependent EmployeeDependent)
        {
            Response forcast;
            if (EmployeeDependent.ID == 0)
            {
                forcast = await _container.EmployeeDependent.Insert(EmployeeDependent);
            }
            else
            {
                forcast = await _container.EmployeeDependent.Update(EmployeeDependent);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "EmployeeDependent");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.EmployeeDependent EmployeeDependent = new DTO.EmployeeDependent
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.EmployeeDependent.Delete(EmployeeDependent);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
