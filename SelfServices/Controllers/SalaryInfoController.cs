using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SelfServices.Controllers
{
    public class SalaryInfoController : Controller
    {
        private readonly IClientContainer _container;
        public SalaryInfoController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.emps = await _container.Employee.GetAll();
            ViewBag.banks = await _container.Bank.GetAll();
            ViewBag.bankbranchs = await _container.BankBranch.GetAll();
            var SalaryInfos = await _container.SalaryInfo.GetAll();
            return View(SalaryInfos);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var employees = await _container.Employee.GetAll();
            var branches = await _container.BankBranch.GetAll();
            var Banks = await _container.Bank.GetAll();

            ViewBag.AllEmployee = new SelectList(employees, "ID", "ForeignFirstName");
            ViewBag.AllBankBranch = new SelectList(branches, "ID", "BranchName");
            ViewBag.AllBank = new SelectList(Banks, "ID", "BankName");
            var SalaryInfo = await _container.SalaryInfo.GetByID(Id);
            return View(SalaryInfo);
        }
        public async Task<IActionResult> Save(DTO.SalaryInfo SalaryInfo)
        {
            int IsCurrent = Convert.ToInt32(Request.Form["IsCurrent"]);
            if (IsCurrent == 0)
            {
                SalaryInfo.IsCurrent = false;
            }
            else
            {
                SalaryInfo.IsCurrent= true;
            }
            Response forcast;
            if (SalaryInfo.ID == 0)
            {
                forcast = await _container.SalaryInfo.Insert(SalaryInfo);
            }
            else
            {
                forcast = await _container.SalaryInfo.Update(SalaryInfo);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "SalaryInfo");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.SalaryInfo SalaryInfo = new DTO.SalaryInfo
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.SalaryInfo.Delete(SalaryInfo);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
