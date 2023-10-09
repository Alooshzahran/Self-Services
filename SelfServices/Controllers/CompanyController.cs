using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IClientContainer _container;
        public CompanyController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Companys = await _container.Company.GetAll();
            return View(Companys);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Company = await _container.Company.GetByID(Id);
            return View(Company);
        }
        public async Task<IActionResult> Save(DTO.Company Company)
        {
            var photo = Request.Form.Files["Logo"];
            Company.Logo = photo.FileName;
            Response forcast;
            if (Company.ID == 0)
            {
                forcast = await _container.Company.Insert(Company);
            }
            else
            {
                forcast = await _container.Company.Update(Company);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Company Company = new DTO.Company
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Company.Delete(Company);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
