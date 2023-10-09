using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public MaritalStatusController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.MaritalStatus> EntityMaritalStatus = _unitofwork.maritalStatus.GetAll().ToList();
            var DtoMaritalStatus = _Map.Map<List<DTO.MaritalStatus>>(EntityMaritalStatus);
            return Ok(DtoMaritalStatus);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityMaritalStatusType = _unitofwork.maritalStatus.GetByID(Id);
            var DTOMaritalStatusType = _Map.Map<DTO.MaritalStatus>(EntityMaritalStatusType);

            return Ok(DTOMaritalStatusType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.MaritalStatus MaritalStatus)
        {

            Entity.MaritalStatus NewMaritalStatus = _Map.Map<Entity.MaritalStatus>(MaritalStatus);

            NewMaritalStatus.CreationDate = DateTime.UtcNow;
            _unitofwork.maritalStatus.Create(NewMaritalStatus);
            _unitofwork.Complete();

            MaritalStatus.ID = NewMaritalStatus.ID;
            return Ok(MaritalStatus);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.MaritalStatus MaritalStatus)
        {


            var EntityMaritalStatus = _Map.Map<Entity.MaritalStatus>(MaritalStatus);
            _unitofwork.maritalStatus.Update(EntityMaritalStatus);
            _unitofwork.Complete();
            MaritalStatus = _Map.Map<DTO.MaritalStatus>(EntityMaritalStatus);
            return Ok(MaritalStatus);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.MaritalStatus MaritalStatus)
        {
            var EntityMaritalStatus = _unitofwork.maritalStatus.GetByID(MaritalStatus.ID);
            if (EntityMaritalStatus != null)
            {


                EntityMaritalStatus.IsDeleted = true;
                EntityMaritalStatus.DeleteDate = DateTime.UtcNow;
                EntityMaritalStatus.DeleteUserID = MaritalStatus.DeleteUserID;
                _unitofwork.Complete();
                var DTOMaritalStatus = _Map.Map<DTO.MaritalStatus>(EntityMaritalStatus);
                return Ok(DTOMaritalStatus);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
