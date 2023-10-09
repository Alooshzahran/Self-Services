using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class ShiftTypeController : Controller
    {
        private readonly IClientContainer _container;
        public ShiftTypeController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var ShiftTypes = await _container.ShiftType.GetAll();
            return View(ShiftTypes);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var ShiftType = await _container.ShiftType.GetByID(Id);
            return View(ShiftType);
        }
        public async Task<IActionResult> Save(DTO.ShiftType ShiftType)
        {
            Response forcast;
            if (ShiftType.ID == 0)
            {
                forcast = await _container.ShiftType.Insert(ShiftType);
            }
            else
            {
                forcast = await _container.ShiftType.Update(ShiftType);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "ShiftType");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.ShiftType ShiftType = new DTO.ShiftType
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.ShiftType.Delete(ShiftType);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
