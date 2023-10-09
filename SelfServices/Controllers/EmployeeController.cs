using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelfServices.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IClientContainer _container;
        public EmployeeController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Employees = await _container.Employee.GetAll();
            return View(Employees);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {

            var employees = await _container.Employee.GetAll();
            var Gender = await _container.Gender.GetAll();
            var MaritalStatus = await _container.MaritalStatus.GetAll();
            var Country = await _container.Country.GetAll();
            var JobDescription = await _container.JobDescription.GetAll();
            var Nationality = await _container.Nationality.GetAll();
            var Grade = await _container.Grade.GetAll();


            ViewBag.AllGender = new SelectList(Gender, "ID", "Name"); ;
            ViewBag.AllNationality = new SelectList(Nationality, "ID", "Name"); ;
            ViewBag.AllMaritalStatus = new SelectList(MaritalStatus, "ID", "Name");
            ViewBag.AllCountry = new SelectList(Country, "ID", "CountryName");
            ViewBag.AllEmployee = new SelectList(employees, "ID", "ForeignFirstName");
            ViewBag.AllJobDescription = new SelectList(JobDescription, "ID", "Name");
            ViewBag.AllGrade = new SelectList(Grade, "ID", "Name");


            var Employee = await _container.Employee.GetByID(Id);
            return View(Employee);
        }
        public async Task<IActionResult> Save(DTO.Employee Employee)
        {
            Response forcast;
            if (Employee.ID == 0)
            {
                forcast = await _container.Employee.Insert(Employee);
            }
            else
            {
                forcast = await _container.Employee.Update(Employee);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Employee Employee = new DTO.Employee
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Employee.Delete(Employee);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
