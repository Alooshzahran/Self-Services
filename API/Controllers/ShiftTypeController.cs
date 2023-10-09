using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public ShiftTypeController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.ShiftType> EntityShiftType = _unitofwork.shiftType.GetAll().ToList();
            var DtoShiftType = _Map.Map<List<DTO.ShiftType>>(EntityShiftType);
            return Ok(DtoShiftType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityShiftTypeType = _unitofwork.shiftType.GetByID(Id);
            var DTOShiftTypeType = _Map.Map<DTO.ShiftType>(EntityShiftTypeType);

            return Ok(DTOShiftTypeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.ShiftType ShiftType)
        {

            Entity.ShiftType NewShiftType = _Map.Map<Entity.ShiftType>(ShiftType);

            NewShiftType.CreationDate = DateTime.UtcNow;
            _unitofwork.shiftType.Create(NewShiftType);
            _unitofwork.Complete();

            ShiftType.ID = NewShiftType.ID;
            return Ok(ShiftType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.ShiftType ShiftType)
        {


            var EntityShiftType = _Map.Map<Entity.ShiftType>(ShiftType);
            _unitofwork.shiftType.Update(EntityShiftType);
            _unitofwork.Complete();
            ShiftType = _Map.Map<DTO.ShiftType>(EntityShiftType);
            return Ok(ShiftType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.ShiftType ShiftType)
        {
            var EntityShiftType = _unitofwork.shiftType.GetByID(ShiftType.ID);
            if (EntityShiftType != null)
            {


                EntityShiftType.IsDeleted = true;
                EntityShiftType.DeleteDate = DateTime.UtcNow;
                EntityShiftType.DeleteUserID = ShiftType.DeleteUserID;
                _unitofwork.Complete();
                var DTOShiftType = _Map.Map<DTO.ShiftType>(EntityShiftType);
                return Ok(DTOShiftType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
