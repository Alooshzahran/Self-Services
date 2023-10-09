using Connecter.Client;
using Connecter.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class AllowanceTypeController : Controller
    {
        private readonly IClientContainer _container;
        public AllowanceTypeController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Allowances = await _container.AllowanceType.GetAll();
            return View(Allowances);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var allowance = await _container.AllowanceType.GetByID(Id);
            return View(allowance);
        }
        public async Task<IActionResult> Save(DTO.AllowanceType allowanceType)
        {
            Response forcast;
            if (allowanceType.ID == 0)
            {
                forcast = await _container.AllowanceType.Insert(allowanceType);
            }
            else
            {
                forcast = await _container.AllowanceType.Update(allowanceType);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index","AllowanceType");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.AllowanceType AllowanceType = new DTO.AllowanceType
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.AllowanceType.Delete(AllowanceType);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
