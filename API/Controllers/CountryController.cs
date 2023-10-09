using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public CountryController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Country> EntityCountry = _unitofwork.country.GetAll().ToList();
            var DtoCountry = _Map.Map<List<DTO.Country>>(EntityCountry);
            return Ok(DtoCountry);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityCountryType = _unitofwork.country.GetByID(Id);
            var DTOCountryType = _Map.Map<DTO.Country>(EntityCountryType);

            return Ok(DTOCountryType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Country Country)
        {

            Entity.Country NewCountry = _Map.Map<Entity.Country>(Country);

            NewCountry.CreationDate = DateTime.UtcNow;
            _unitofwork.country.Create(NewCountry);
            _unitofwork.Complete();

            Country.ID = NewCountry.ID;
            return Ok(Country);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Country Country)
        {


            var EntityCountry = _Map.Map<Entity.Country>(Country);
            _unitofwork.country.Update(EntityCountry);
            _unitofwork.Complete();
            Country = _Map.Map<DTO.Country>(EntityCountry);
            return Ok(Country);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Country Country)
        {
            var EntityCountry = _unitofwork.country.GetByID(Country.ID);
            if (EntityCountry != null)
            {


                EntityCountry.IsDeleted = true;
                EntityCountry.DeleteDate = DateTime.UtcNow;
                EntityCountry.DeleteUserID = Country.DeleteUserID;
                _unitofwork.Complete();
                var DTOCountry = _Map.Map<DTO.Country>(EntityCountry);
                return Ok(DTOCountry);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
