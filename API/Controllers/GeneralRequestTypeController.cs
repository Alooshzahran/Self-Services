using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralRequestTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralRequestTypeController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralRequestType> EntityGeneralRequestType = _unitofwork.generalRequestType.GetAll().ToList();
            var DtoGeneralRequestType = _Map.Map<List<DTO.GeneralRequestType>>(EntityGeneralRequestType);
            return Ok(DtoGeneralRequestType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralRequestTypeType = _unitofwork.generalRequestType.GetByID(Id);
            var DTOGeneralRequestTypeType = _Map.Map<DTO.GeneralRequestType>(EntityGeneralRequestTypeType);

            return Ok(DTOGeneralRequestTypeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralRequestType GeneralRequestType)
        {

            Entity.GeneralRequestType NewGeneralRequestType = _Map.Map<Entity.GeneralRequestType>(GeneralRequestType);

            NewGeneralRequestType.CreationDate = DateTime.UtcNow;
            _unitofwork.generalRequestType.Create(NewGeneralRequestType);
            _unitofwork.Complete();

            GeneralRequestType.ID = NewGeneralRequestType.ID;
            return Ok(GeneralRequestType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralRequestType GeneralRequestType)
        {


            var EntityGeneralRequestType = _Map.Map<Entity.GeneralRequestType>(GeneralRequestType);
            _unitofwork.generalRequestType.Update(EntityGeneralRequestType);
            _unitofwork.Complete();
            GeneralRequestType = _Map.Map<DTO.GeneralRequestType>(EntityGeneralRequestType);
            return Ok(GeneralRequestType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralRequestType GeneralRequestType)
        {
            var EntityGeneralRequestType = _unitofwork.generalRequestType.GetByID(GeneralRequestType.ID);
            if (EntityGeneralRequestType != null)
            {


                EntityGeneralRequestType.IsDeleted = true;
                EntityGeneralRequestType.DeleteDate = DateTime.UtcNow;
                EntityGeneralRequestType.DeleteUserID = GeneralRequestType.DeleteUserID;
                _unitofwork.Complete();
                var DTOGeneralRequestType = _Map.Map<DTO.GeneralRequestType>(EntityGeneralRequestType);
                return Ok(DTOGeneralRequestType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
