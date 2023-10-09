using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class MaritalStatusController : Controller
    {
        private readonly IClientContainer _container;
        public MaritalStatusController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var MaritalStatuss = await _container.MaritalStatus.GetAll();
            return View(MaritalStatuss);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var MaritalStatus = await _container.MaritalStatus.GetByID(Id);
            return View(MaritalStatus);
        }
        public async Task<IActionResult> Save(DTO.MaritalStatus MaritalStatus)
        {
            Response forcast;
            if (MaritalStatus.ID == 0)
            {
                forcast = await _container.MaritalStatus.Insert(MaritalStatus);
            }
            else
            {
                forcast = await _container.MaritalStatus.Update(MaritalStatus);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "MaritalStatus");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.MaritalStatus MaritalStatus = new DTO.MaritalStatus
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.MaritalStatus.Delete(MaritalStatus);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
