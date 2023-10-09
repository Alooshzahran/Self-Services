using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IClientContainer _container;
        public RelationshipController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var Relationships = await _container.Relationship.GetAll();
            return View(Relationships);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var Relationship = await _container.Relationship.GetByID(Id);
            return View(Relationship);
        }
        public async Task<IActionResult> Save(DTO.Relationship Relationship)
        {
            Response forcast;
            if (Relationship.ID == 0)
            {
                forcast = await _container.Relationship.Insert(Relationship);
            }
            else
            {
                forcast = await _container.Relationship.Update(Relationship);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "Relationship");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.Relationship Relationship = new DTO.Relationship
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.Relationship.Delete(Relationship);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
