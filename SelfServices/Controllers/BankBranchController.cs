 using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace SelfServices.Controllers
{
    public class BankBranchController : Controller
    {
        private readonly IClientContainer _container;
        public BankBranchController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Banks = await _container.Bank.GetAll();
            var BankBranchs = await _container.BankBranch.GetAll();
            return View(BankBranchs);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Banks = await _container.Bank.GetAll();
            ViewBag.Banks = new SelectList(Banks, "ID", "BankName"); ;
            var Bank = await _container.BankBranch.GetByID(Id);
            return View(Bank);
        }
        public async Task<IActionResult> Save(DTO.BankBranch BankBranch)
        {
            Response forcast;
            if (BankBranch.ID == 0)
            {
                forcast = await _container.BankBranch.Insert(BankBranch);
            }
            else
            {
                forcast = await _container.BankBranch.Update(BankBranch);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "BankBranch");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.BankBranch BankBranch = new DTO.BankBranch
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.BankBranch.Delete(BankBranch);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
