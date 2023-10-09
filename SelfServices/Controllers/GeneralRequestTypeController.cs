using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class GeneralRequestTypeController : Controller
    {
        private readonly IClientContainer _container;
        public GeneralRequestTypeController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var GeneralRequestTypes = await _container.GeneralRequestType.GetAll();
            return View(GeneralRequestTypes);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var GeneralRequestType = await _container.GeneralRequestType.GetByID(Id);
            return View(GeneralRequestType);
        }
        public async Task<IActionResult> Save(DTO.GeneralRequestType GeneralRequestType)
        {
            Response forcast;
            if (GeneralRequestType.ID == 0)
            {
                forcast = await _container.GeneralRequestType.Insert(GeneralRequestType);
            }
            else
            {
                forcast = await _container.GeneralRequestType.Update(GeneralRequestType);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "GeneralRequestType");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.GeneralRequestType GeneralRequestType = new DTO.GeneralRequestType
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.GeneralRequestType.Delete(GeneralRequestType);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
