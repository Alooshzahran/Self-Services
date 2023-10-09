using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class GradeController : Controller
    {
        private readonly IClientContainer _container;
        public GradeController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Grades = await _container.Grade.GetAll();
            return View(Grades);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Grade = await _container.Grade.GetByID(Id);
            return View(Grade);
        }
        public async Task<IActionResult> Save(DTO.Grade Grade)
        {
            Response forcast;
            if (Grade.ID == 0)
            {
                forcast = await _container.Grade.Insert(Grade);
            }
            else
            {
                forcast = await _container.Grade.Update(Grade);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Grade");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Grade Grade = new DTO.Grade
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Grade.Delete(Grade);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
