using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class GeneralRequestController : Controller
    {
        private readonly IClientContainer _container;
        public GeneralRequestController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var GeneralRequests = await _container.GeneralRequest.GetAll();
            return View(GeneralRequests);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var GeneralRequest = await _container.GeneralRequest.GetByID(Id);
            return View(GeneralRequest);
        }
        public async Task<IActionResult> Save(DTO.GeneralRequest GeneralRequest)
        {
            Response forcast;
            if (GeneralRequest.ID == 0)
            {
                forcast = await _container.GeneralRequest.Insert(GeneralRequest);
            }
            else
            {
                forcast = await _container.GeneralRequest.Update(GeneralRequest);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "GeneralRequest");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.GeneralRequest GeneralRequest = new DTO.GeneralRequest
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.GeneralRequest.Delete(GeneralRequest);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
