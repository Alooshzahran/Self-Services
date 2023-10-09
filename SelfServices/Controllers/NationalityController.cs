using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class NationalityController : Controller
    {
        private readonly IClientContainer _container;
        public NationalityController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Nationalitys = await _container.Nationality.GetAll();
            return View(Nationalitys);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Nationality = await _container.Nationality.GetByID(Id);
            return View(Nationality);
        }
        public async Task<IActionResult> Save(DTO.Nationality Nationality)
        {
            int Rnationalno = Convert.ToInt32(Request.Form["IsRequiredNationalNo"]);
            int IsAllowedSocialSecurityNo = Convert.ToInt32(Request.Form["IsAllowedSocialSecurityNo"]);
            int IsPassportNumber = Convert.ToInt32(Request.Form["IsPassportNumber"]);
            int IsIqamaNO = Convert.ToInt32(Request.Form["IsIqamaNO"]);
            int IsDefault = Convert.ToInt32(Request.Form["IsDefault"]);
            if (Rnationalno == 0)
            {
                Nationality.IsRequiredNationalNo = false;
            }
            else
            {
                Nationality.IsRequiredNationalNo = true;
            }
            if (IsAllowedSocialSecurityNo == 0)
            {
                Nationality.IsAllowedSocialSecurityNo = false;
            }
            else
            {
                Nationality.IsAllowedSocialSecurityNo = true;
            }
            if (IsPassportNumber == 0)
            {
                Nationality.IsPassportNumber = false;
            }
            else
            {
                Nationality.IsPassportNumber = true;
            }
            if (IsIqamaNO == 0)
            {
                Nationality.IsIqamaNO = false;
            }
            else
            {
                Nationality.IsIqamaNO = true;
            }
            if (IsDefault == 0)
            {
                Nationality.IsDefault = false;
            }
            else
            {
                Nationality.IsDefault = true;
            }
            Response forcast;
            if (Nationality.ID == 0)
            {
                forcast = await _container.Nationality.Insert(Nationality);
            }
            else
            {
                forcast = await _container.Nationality.Update(Nationality);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Nationality");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Nationality Nationality = new DTO.Nationality
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Nationality.Delete(Nationality);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
