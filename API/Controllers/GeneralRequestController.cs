using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralRequestController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralRequestController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralRequest> EntityGeneralRequest = _unitofwork.generalRequest.GetAll().ToList();
            var DtoGeneralRequest = _Map.Map<List<DTO.GeneralRequest>>(EntityGeneralRequest);
            return Ok(DtoGeneralRequest);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralRequestType = _unitofwork.generalRequest.GetByID(Id);
            var DTOGeneralRequestType = _Map.Map<DTO.GeneralRequest>(EntityGeneralRequestType);

            return Ok(DTOGeneralRequestType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralRequest GeneralRequest)
        {

            Entity.GeneralRequest NewGeneralRequest = _Map.Map<Entity.GeneralRequest>(GeneralRequest);

            NewGeneralRequest.CreationDate = DateTime.UtcNow;
            _unitofwork.generalRequest.Create(NewGeneralRequest);
            _unitofwork.Complete();

            GeneralRequest.ID = NewGeneralRequest.ID;
            return Ok(GeneralRequest);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralRequest GeneralRequest)
        {


            var EntityGeneralRequest = _Map.Map<Entity.GeneralRequest>(GeneralRequest);
            _unitofwork.generalRequest.Update(EntityGeneralRequest);
            _unitofwork.Complete();
            GeneralRequest = _Map.Map<DTO.GeneralRequest>(EntityGeneralRequest);
            return Ok(GeneralRequest);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralRequest GeneralRequest)
        {
            var EntityGeneralRequest = _unitofwork.generalRequest.GetByID(GeneralRequest.ID);
            if (EntityGeneralRequest != null)
            {


                EntityGeneralRequest.IsDeleted = true;
                EntityGeneralRequest.DeleteDate = DateTime.UtcNow;
                EntityGeneralRequest.DeleteUserID = GeneralRequest.DeleteUserID;
                _unitofwork.Complete();
                var DTOGeneralRequest = _Map.Map<DTO.GeneralRequest>(EntityGeneralRequest);
                return Ok(DTOGeneralRequest);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
