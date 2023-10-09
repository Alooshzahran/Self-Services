using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class UserController : Controller
    {
        private readonly IClientContainer _container;
        public UserController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Users = await _container.User.GetAll();
            return View(Users);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var User = await _container.User.GetByID(Id);
            return View(User);
        }
        public async Task<IActionResult> Save(DTO.User User)
        {
            Response forcast;
            if (User.ID == 0)
            {
                forcast = await _container.User.Insert(User);
            }
            else
            {
                forcast = await _container.User.Update(User);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.User User = new DTO.User
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.User.Delete(User);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
