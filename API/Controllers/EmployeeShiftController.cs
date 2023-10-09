using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public EmployeeShiftController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.EmployeeShift> EntityEmployeeShift = _unitofwork.employeeShift.GetAll().ToList();
            var DtoEmployeeShift = _Map.Map<List<DTO.EmployeeShift>>(EntityEmployeeShift);
            return Ok(DtoEmployeeShift);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityEmployeeShiftType = _unitofwork.employeeShift.GetByID(Id);
            var DTOEmployeeShiftType = _Map.Map<DTO.EmployeeShift>(EntityEmployeeShiftType);

            return Ok(DTOEmployeeShiftType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByTime(DateTime From)
        {
            var EntityEmployeeShiftType = _unitofwork.employeeShift.GetByTime(From);
            var DTOEmployeeShiftType = _Map.Map<DTO.EmployeeShift>(EntityEmployeeShiftType);

            return Ok(DTOEmployeeShiftType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.EmployeeShift EmployeeShift)
        {

            Entity.EmployeeShift NewEmployeeShift = _Map.Map<Entity.EmployeeShift>(EmployeeShift);

            NewEmployeeShift.CreationDate = DateTime.UtcNow;
            _unitofwork.employeeShift.Create(NewEmployeeShift);
            _unitofwork.Complete();

            EmployeeShift.ID = NewEmployeeShift.ID;
            return Ok(EmployeeShift);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.EmployeeShift EmployeeShift)
        {


            var EntityEmployeeShift = _Map.Map<Entity.EmployeeShift>(EmployeeShift);
            _unitofwork.employeeShift.Update(EntityEmployeeShift);
            _unitofwork.Complete();
            EmployeeShift = _Map.Map<DTO.EmployeeShift>(EntityEmployeeShift);
            return Ok(EmployeeShift);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.EmployeeShift EmployeeShift)
        {
            var EntityEmployeeShift = _unitofwork.employeeShift.GetByID(EmployeeShift.ID);
            if (EntityEmployeeShift != null)
            {


                EntityEmployeeShift.IsDeleted = true;
                EntityEmployeeShift.DeleteDate = DateTime.UtcNow;
                EntityEmployeeShift.DeleteUserID = EmployeeShift.DeleteUserID;
                _unitofwork.Complete();
                var DTOEmployeeShift = _Map.Map<DTO.EmployeeShift>(EntityEmployeeShift);
                return Ok(DTOEmployeeShift);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
