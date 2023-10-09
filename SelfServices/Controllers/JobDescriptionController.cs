using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace SelfServices.Controllers
{
    public class JobDescriptionController : Controller
    {
        private readonly IClientContainer _container;
        public JobDescriptionController(IClientContainer container)
        {
            _container = container;
        }
        public async Task<IActionResult> Index()
        {
            var JobDescriptions = await _container.JobDescription.GetAll();
            return View(JobDescriptions);
        }
        public async Task<IActionResult> AddEdit(int Id)
        {
            var JobDescription = await _container.JobDescription.GetByID(Id);
            return View(JobDescription);
        }
        public async Task<IActionResult> Save(DTO.JobDescription JobDescription)
        {
            Response forcast;
            if (JobDescription.ID == 0)
            {
                forcast = await _container.JobDescription.Insert(JobDescription);
            }
            else
            {
                forcast = await _container.JobDescription.Update(JobDescription);
            }
            if (forcast.IsSuccess)
            {
                return RedirectToAction("Index", "JobDescription");
            }
            else
            {
                return View();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int ID)
        {

            DTO.JobDescription JobDescription = new DTO.JobDescription
            {
                ID = ID,

                IsDeleted = true
            };
            var Forcast = await _container.JobDescription.Delete(JobDescription);

            if (Forcast != null)
            {
                return Json(Forcast);

            }
            else
                return null;

        }
    }
}
