using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public RelationshipController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Relationship> EntityRelationship = _unitofwork.relationship.GetAll().ToList();
            var DtoRelationship = _Map.Map<List<DTO.Relationship>>(EntityRelationship);
            return Ok(DtoRelationship);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityRelationshipType = _unitofwork.relationship.GetByID(Id);
            var DTORelationshipType = _Map.Map<DTO.Relationship>(EntityRelationshipType);

            return Ok(DTORelationshipType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Relationship Relationship)
        {

            Entity.Relationship NewRelationship = _Map.Map<Entity.Relationship>(Relationship);

            NewRelationship.CreationDate = DateTime.UtcNow;
            _unitofwork.relationship.Create(NewRelationship);
            _unitofwork.Complete();

            Relationship.ID = NewRelationship.ID;
            return Ok(Relationship);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Relationship Relationship)
        {


            var EntityRelationship = _Map.Map<Entity.Relationship>(Relationship);
            _unitofwork.relationship.Update(EntityRelationship);
            _unitofwork.Complete();
            Relationship = _Map.Map<DTO.Relationship>(EntityRelationship);
            return Ok(Relationship);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Relationship Relationship)
        {
            var EntityRelationship = _unitofwork.relationship.GetByID(Relationship.ID);
            if (EntityRelationship != null)
            {


                EntityRelationship.IsDeleted = true;
                EntityRelationship.DeleteDate = DateTime.UtcNow;
                EntityRelationship.DeleteUserID = Relationship.DeleteUserID;
                _unitofwork.Complete();
                var DTORelationship = _Map.Map<DTO.Relationship>(EntityRelationship);
                return Ok(DTORelationship);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
