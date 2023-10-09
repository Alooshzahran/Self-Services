using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryInfoController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public SalaryInfoController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.SalaryInfo> EntitySalaryInfo = _unitofwork.salaryInfo.GetAll().ToList();
            var DtoSalaryInfo = _Map.Map<List<DTO.SalaryInfo>>(EntitySalaryInfo);
            return Ok(DtoSalaryInfo);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntitySalaryInfoType = _unitofwork.salaryInfo.GetByID(Id);
            var DTOSalaryInfoType = _Map.Map<DTO.SalaryInfo>(EntitySalaryInfoType);

            return Ok(DTOSalaryInfoType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.SalaryInfo SalaryInfo)
        {

            Entity.SalaryInfo NewSalaryInfo = _Map.Map<Entity.SalaryInfo>(SalaryInfo);

            NewSalaryInfo.CreationDate = DateTime.UtcNow;
            _unitofwork.salaryInfo.Create(NewSalaryInfo);
            _unitofwork.Complete();

            SalaryInfo.ID = NewSalaryInfo.ID;
            return Ok(SalaryInfo);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.SalaryInfo SalaryInfo)
        {


            var EntitySalaryInfo = _Map.Map<Entity.SalaryInfo>(SalaryInfo);
            _unitofwork.salaryInfo.Update(EntitySalaryInfo);
            _unitofwork.Complete();
            SalaryInfo = _Map.Map<DTO.SalaryInfo>(EntitySalaryInfo);
            return Ok(SalaryInfo);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.SalaryInfo SalaryInfo)
        {
            var EntitySalaryInfo = _unitofwork.salaryInfo.GetByID(SalaryInfo.ID);
            if (EntitySalaryInfo != null)
            {


                EntitySalaryInfo.IsDeleted = true;
                EntitySalaryInfo.DeleteDate = DateTime.UtcNow;
                EntitySalaryInfo.DeleteUserID = SalaryInfo.DeleteUserID;
                _unitofwork.Complete();
                var DTOSalaryInfo = _Map.Map<DTO.SalaryInfo>(EntitySalaryInfo);
                return Ok(DTOSalaryInfo);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
