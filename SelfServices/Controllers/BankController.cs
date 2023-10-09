using Connecter.Client;
using Connecter.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace SelfServices.Controllers
{
    public class BankController : Controller
    {
        private readonly IClientContainer _container;
        public BankController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Banks = await _container.Bank.GetAll();
            return View(Banks);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Bank = await _container.Bank.GetByID(Id);
            return View(Bank);
        }
        public async Task<IActionResult> Save(DTO.Bank Bank)
        {
            Response forcast;
            if (Bank.ID == 0)
            {
                forcast = await _container.Bank.Insert(Bank);
            }
            else
            {
                forcast = await _container.Bank.Update(Bank);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Bank");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Bank Bank = new DTO.Bank
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Bank.Delete(Bank);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
