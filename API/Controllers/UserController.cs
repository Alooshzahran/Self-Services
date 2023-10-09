using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public UserController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.User> EntityUser = _unitofwork.user.GetAll().ToList();
            //var DtoUser = _Map.Map<List<DTO.User>>(EntityUser);
            return Ok(EntityUser);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityUserType = _unitofwork.user.GetByID(Id);
            var DTOUserType = _Map.Map<DTO.User>(EntityUserType);

            return Ok(DTOUserType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.User User)
        {

            Entity.User NewUser = _Map.Map<Entity.User>(User);

            NewUser.CreationDate = DateTime.UtcNow;
            _unitofwork.user.Create(NewUser);
            _unitofwork.Complete();

            User.ID = NewUser.ID;
            return Ok(User);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.User User)
        {


            var EntityUser = _Map.Map<Entity.User>(User);
            _unitofwork.user.Update(EntityUser);
            _unitofwork.Complete();
            User = _Map.Map<DTO.User>(EntityUser);
            return Ok(User);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.User User)
        {
            var EntityUser = _unitofwork.user.GetByID(User.ID);
            if (EntityUser != null)
            {


                EntityUser.IsDeleted = true;
                EntityUser.DeletDate = DateTime.UtcNow;
                _unitofwork.Complete();
                var DTOUser = _Map.Map<DTO.User>(EntityUser);
                return Ok(DTOUser);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
