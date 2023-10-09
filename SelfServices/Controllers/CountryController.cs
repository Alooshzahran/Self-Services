using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class CountryController : Controller
    {
        private readonly IClientContainer _container;
        public CountryController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Countrys = await _container.Country.GetAll();
            return View(Countrys);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Country = await _container.Country.GetByID(Id);
            return View(Country);
        }
        public async Task<IActionResult> Save(DTO.Country Country)
        {
            Response forcast;
            if (Country.ID == 0)
            {
                forcast = await _container.Country.Insert(Country);
            }
            else
            {
                forcast = await _container.Country.Update(Country);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Country");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Country Country = new DTO.Country
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Country.Delete(Country);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
