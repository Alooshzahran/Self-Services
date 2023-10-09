using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public CompanyController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Company> EntityCompany = _unitofwork.company.GetAll().ToList();
            var DtoCompany = _Map.Map<List<DTO.Company>>(EntityCompany);
            return Ok(DtoCompany);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityCompanyType = _unitofwork.company.GetByID(Id);
            var DTOCompanyType = _Map.Map<DTO.Company>(EntityCompanyType);

            return Ok(DTOCompanyType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Company Company)
        {

            Entity.Company NewCompany = _Map.Map<Entity.Company>(Company);

            NewCompany.CreationDate = DateTime.UtcNow;
            _unitofwork.company.Create(NewCompany);
            _unitofwork.Complete();

            Company.ID = NewCompany.ID;
            return Ok(Company);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Company Company)
        {


            var EntityCompany = _Map.Map<Entity.Company>(Company);
            _unitofwork.company.Update(EntityCompany);
            _unitofwork.Complete();
            Company = _Map.Map<DTO.Company>(EntityCompany);
            return Ok(Company);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Company Company)
        {
            var EntityCompany = _unitofwork.company.GetByID(Company.ID);
            if (EntityCompany != null)
            {


                EntityCompany.IsDeleted = true;
                EntityCompany.DeleteDate = DateTime.UtcNow;
                EntityCompany.DeleteUserID = Company.DeleteUserID;
                _unitofwork.Complete();
                var DTOCompany = _Map.Map<DTO.Company>(EntityCompany);
                return Ok(DTOCompany);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
