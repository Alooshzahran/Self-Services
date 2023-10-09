using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public EmployeeController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Employee> EntityEmployee = _unitofwork.employee.GetAll().ToList();
            var DtoEmployee = _Map.Map<List<DTO.Employee>>(EntityEmployee);
            return Ok(DtoEmployee);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityEmployeeType = _unitofwork.employee.GetByID(Id);
            var DTOEmployeeType = _Map.Map<DTO.Employee>(EntityEmployeeType);

            return Ok(DTOEmployeeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Employee Employee)
        {

            Entity.Employee NewEmployee = _Map.Map<Entity.Employee>(Employee);

            NewEmployee.CreationDate = DateTime.UtcNow;
            _unitofwork.employee.Create(NewEmployee);
            _unitofwork.Complete();

            Employee.ID = NewEmployee.ID;
            return Ok(Employee);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Employee Employee)
        {


            var EntityEmployee = _Map.Map<Entity.Employee>(Employee);
            _unitofwork.employee.Update(EntityEmployee);
            _unitofwork.Complete();
            Employee = _Map.Map<DTO.Employee>(EntityEmployee);
            return Ok(Employee);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Employee Employee)
        {
            var EntityEmployee = _unitofwork.employee.GetByID(Employee.ID);
            if (EntityEmployee != null)
            {


                EntityEmployee.IsDeleted = true;
                EntityEmployee.DeleteDate = DateTime.UtcNow;
                EntityEmployee.DeleteUserID = Employee.DeleteUserID;
                _unitofwork.Complete();
                var DTOEmployee = _Map.Map<DTO.Employee>(EntityEmployee);
                return Ok(DTOEmployee);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
