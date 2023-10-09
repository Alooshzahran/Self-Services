using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public NationalityController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Nationality> EntityNationality = _unitofwork.National.GetAll().ToList();
            var DtoNationality = _Map.Map<List<DTO.Nationality>>(EntityNationality);
            return Ok(DtoNationality);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityNationalityType = _unitofwork.National.GetByID(Id);
            var DTONationalityType = _Map.Map<DTO.Nationality>(EntityNationalityType);

            return Ok(DTONationalityType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Nationality Nationality)
        {

            Entity.Nationality NewNationality = _Map.Map<Entity.Nationality>(Nationality);

            NewNationality.CreationDate = DateTime.UtcNow;
            _unitofwork.National.Create(NewNationality);
            _unitofwork.Complete();

            Nationality.ID = NewNationality.ID;
            return Ok(Nationality);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Nationality Nationality)
        {


            var EntityNationality = _Map.Map<Entity.Nationality>(Nationality);
            _unitofwork.National.Update(EntityNationality);
            _unitofwork.Complete();
            Nationality = _Map.Map<DTO.Nationality>(EntityNationality);
            return Ok(Nationality);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Nationality Nationality)
        {
            var EntityNationality = _unitofwork.National.GetByID(Nationality.ID);
            if (EntityNationality != null)
            {


                EntityNationality.IsDeleted = true;
                EntityNationality.DeleteDate = DateTime.UtcNow;
                EntityNationality.DeleteUserID = Nationality.DeleteUserID;
                _unitofwork.Complete();
                var DTONationality = _Map.Map<DTO.Nationality>(EntityNationality);
                return Ok(DTONationality);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
