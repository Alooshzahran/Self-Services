using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDescriptionController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public JobDescriptionController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.JobDescription> EntityJobDescription = _unitofwork.jobDescription.GetAll().ToList();
            var DtoJobDescription = _Map.Map<List<DTO.JobDescription>>(EntityJobDescription);
            return Ok(DtoJobDescription);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityJobDescriptionType = _unitofwork.jobDescription.GetByID(Id);
            var DTOJobDescriptionType = _Map.Map<DTO.JobDescription>(EntityJobDescriptionType);

            return Ok(DTOJobDescriptionType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.JobDescription JobDescription)
        {

            Entity.JobDescription NewJobDescription = _Map.Map<Entity.JobDescription>(JobDescription);

            NewJobDescription.CreationDate = DateTime.UtcNow;
            _unitofwork.jobDescription.Create(NewJobDescription);
            _unitofwork.Complete();

            JobDescription.ID = NewJobDescription.ID;
            return Ok(JobDescription);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.JobDescription JobDescription)
        {


            var EntityJobDescription = _Map.Map<Entity.JobDescription>(JobDescription);
            _unitofwork.jobDescription.Update(EntityJobDescription);
            _unitofwork.Complete();
            JobDescription = _Map.Map<DTO.JobDescription>(EntityJobDescription);
            return Ok(JobDescription);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.JobDescription JobDescription)
        {
            var EntityJobDescription = _unitofwork.jobDescription.GetByID(JobDescription.ID);
            if (EntityJobDescription != null)
            {


                EntityJobDescription.IsDeleted = true;
                EntityJobDescription.DeleteDate = DateTime.UtcNow;
                EntityJobDescription.DeleteUserID = JobDescription.DeleteUserID;
                _unitofwork.Complete();
                var DTOJobDescription = _Map.Map<DTO.JobDescription>(EntityJobDescription);
                return Ok(DTOJobDescription);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
