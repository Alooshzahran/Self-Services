using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowanceTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public AllowanceTypeController(IUnitofwork unitofwork,IMapper Map)
        {
            _unitofwork = unitofwork;   
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.AllowanceType> EntityAllowanceType = _unitofwork.AllowanceType.GetAll().ToList();
            var DtoAllowanceType = _Map.Map<List<DTO.AllowanceType>>(EntityAllowanceType);
            return Ok(DtoAllowanceType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityAllowanceTypeType = _unitofwork.AllowanceType.GetByID(Id);
            var DTOAllowanceTypeType = _Map.Map<DTO.AllowanceType>(EntityAllowanceTypeType);

            return Ok(DTOAllowanceTypeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.AllowanceType AllowanceType)
        {

            Entity.AllowanceType NewAllowanceType = _Map.Map<Entity.AllowanceType>(AllowanceType);

            NewAllowanceType.CreationDate = DateTime.UtcNow;
            _unitofwork.AllowanceType.Create(NewAllowanceType);
            _unitofwork.Complete();

            AllowanceType.ID = NewAllowanceType.ID;
            return Ok(AllowanceType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.AllowanceType AllowanceType)
        {


            var EntityAllowanceType = _Map.Map<Entity.AllowanceType>(AllowanceType);
            _unitofwork.AllowanceType.Update(EntityAllowanceType);
            _unitofwork.Complete();
            AllowanceType = _Map.Map<DTO.AllowanceType>(EntityAllowanceType);
            return Ok(AllowanceType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.AllowanceType AllowanceType)
        {
            var EntityAllowanceType = _unitofwork.AllowanceType.GetByID(AllowanceType.ID);
            if (EntityAllowanceType != null)
            {


                EntityAllowanceType.IsDeleted = true;
                EntityAllowanceType.DeleteDate = DateTime.UtcNow;
                EntityAllowanceType.DeleteUserID = AllowanceType.DeleteUserID;
                _unitofwork.Complete();
                var DTOAllowanceType = _Map.Map<DTO.AllowanceType>(EntityAllowanceType);
                return Ok(DTOAllowanceType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
