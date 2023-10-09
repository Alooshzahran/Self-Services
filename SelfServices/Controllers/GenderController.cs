using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class GenderController : Controller
    {
        private readonly IClientContainer _container;
        public GenderController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Genders = await _container.Gender.GetAll();
            return View(Genders);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Gender = await _container.Gender.GetByID(Id);
            return View(Gender);
        }
        public async Task<IActionResult> Save(DTO.Gender Gender)
        {
            Response forcast;
            if (Gender.ID == 0)
            {
                forcast = await _container.Gender.Insert(Gender);
            }
            else
            {
                forcast = await _container.Gender.Update(Gender);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Gender");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Gender Gender = new DTO.Gender
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Gender.Delete(Gender);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
