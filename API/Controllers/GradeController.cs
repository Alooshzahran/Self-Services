using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GradeController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Grade> EntityGrade = _unitofwork.grade.GetAll().ToList();
            var DtoGrade = _Map.Map<List<DTO.Grade>>(EntityGrade);
            return Ok(DtoGrade);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGradeType = _unitofwork.grade.GetByID(Id);
            var DTOGradeType = _Map.Map<DTO.Grade>(EntityGradeType);

            return Ok(DTOGradeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Grade Grade)
        {

            Entity.Grade NewGrade = _Map.Map<Entity.Grade>(Grade);

            NewGrade.CreationDate = DateTime.UtcNow;
            _unitofwork.grade.Create(NewGrade);
            _unitofwork.Complete();

            Grade.ID = NewGrade.ID;
            return Ok(Grade);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Grade Grade)
        {


            var EntityGrade = _Map.Map<Entity.Grade>(Grade);
            _unitofwork.grade.Update(EntityGrade);
            _unitofwork.Complete();
            Grade = _Map.Map<DTO.Grade>(EntityGrade);
            return Ok(Grade);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Grade Grade)
        {
            var EntityGrade = _unitofwork.grade.GetByID(Grade.ID);
            if (EntityGrade != null)
            {


                EntityGrade.IsDeleted = true;
                EntityGrade.DeleteDate = DateTime.UtcNow;
                EntityGrade.DeleteUserID = Grade.DeleteUserID;
                _unitofwork.Complete();
                var DTOGrade = _Map.Map<DTO.Grade>(EntityGrade);
                return Ok(DTOGrade);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
