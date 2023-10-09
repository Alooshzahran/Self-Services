using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDependentController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public EmployeeDependentController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.EmployeeDependent> EntityEmployeeDependent = _unitofwork.employeeDependent.GetAll().ToList();
            var DtoEmployeeDependent = _Map.Map<List<DTO.EmployeeDependent>>(EntityEmployeeDependent);
            return Ok(DtoEmployeeDependent);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityEmployeeDependentType = _unitofwork.employeeDependent.GetByID(Id);
            var DTOEmployeeDependentType = _Map.Map<DTO.EmployeeDependent>(EntityEmployeeDependentType);

            return Ok(DTOEmployeeDependentType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.EmployeeDependent EmployeeDependent)
        {

            Entity.EmployeeDependent NewEmployeeDependent = _Map.Map<Entity.EmployeeDependent>(EmployeeDependent);

            NewEmployeeDependent.CreationDate = DateTime.UtcNow;
            _unitofwork.employeeDependent.Create(NewEmployeeDependent);
            _unitofwork.Complete();

            EmployeeDependent.ID = NewEmployeeDependent.ID;
            return Ok(EmployeeDependent);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.EmployeeDependent EmployeeDependent)
        {


            var EntityEmployeeDependent = _Map.Map<Entity.EmployeeDependent>(EmployeeDependent);
            _unitofwork.employeeDependent.Update(EntityEmployeeDependent);
            _unitofwork.Complete();
            EmployeeDependent = _Map.Map<DTO.EmployeeDependent>(EntityEmployeeDependent);
            return Ok(EmployeeDependent);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.EmployeeDependent EmployeeDependent)
        {
            var EntityEmployeeDependent = _unitofwork.employeeDependent.GetByID(EmployeeDependent.ID);
            if (EntityEmployeeDependent != null)
            {


                EntityEmployeeDependent.IsDeleted = true;
                EntityEmployeeDependent.DeleteDate = DateTime.UtcNow;
                EntityEmployeeDependent.DeleteUserID = EmployeeDependent.DeleteUserID;
                _unitofwork.Complete();
                var DTOEmployeeDependent = _Map.Map<DTO.EmployeeDependent>(EntityEmployeeDependent);
                return Ok(DTOEmployeeDependent);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
