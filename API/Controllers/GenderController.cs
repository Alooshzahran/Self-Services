using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GenderController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Gender> EntityGender = _unitofwork.gender.GetAll().ToList();
            var DtoGender = _Map.Map<List<DTO.Gender>>(EntityGender);
            return Ok(DtoGender);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGenderType = _unitofwork.gender.GetByID(Id);
            var DTOGenderType = _Map.Map<DTO.Gender>(EntityGenderType);

            return Ok(DTOGenderType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Gender Gender)
        {

            Entity.Gender NewGender = _Map.Map<Entity.Gender>(Gender);

            NewGender.CreationDate = DateTime.UtcNow;
            _unitofwork.gender.Create(NewGender);
            _unitofwork.Complete();

            Gender.ID = NewGender.ID;
            return Ok(Gender);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Gender Gender)
        {


            var EntityGender = _Map.Map<Entity.Gender>(Gender);
            _unitofwork.gender.Update(EntityGender);
            _unitofwork.Complete();
            Gender = _Map.Map<DTO.Gender>(EntityGender);
            return Ok(Gender);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Gender Gender)
        {
            var EntityGender = _unitofwork.gender.GetByID(Gender.ID);
            if (EntityGender != null)
            {


                EntityGender.IsDeleted = true;
                EntityGender.DeleteDate = DateTime.UtcNow;
                EntityGender.DeleteUserID = Gender.DeleteUserID;
                _unitofwork.Complete();
                var DTOGender = _Map.Map<DTO.Gender>(EntityGender);
                return Ok(DTOGender);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
