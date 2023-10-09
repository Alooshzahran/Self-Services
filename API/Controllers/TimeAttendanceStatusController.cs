using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeAttendanceStatusController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public TimeAttendanceStatusController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.TimeAttendanceStatus> EntityTimeAttendanceStatus = _unitofwork.timeAttendanceStatus.GetAll().ToList();
            var DtoTimeAttendanceStatus = _Map.Map<List<DTO.TimeAttendanceStatus>>(EntityTimeAttendanceStatus);
            return Ok(DtoTimeAttendanceStatus);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityTimeAttendanceStatusType = _unitofwork.timeAttendanceStatus.GetByID(Id);
            var DTOTimeAttendanceStatusType = _Map.Map<DTO.TimeAttendanceStatus>(EntityTimeAttendanceStatusType);

            return Ok(DTOTimeAttendanceStatusType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.TimeAttendanceStatus TimeAttendanceStatus)
        {

            Entity.TimeAttendanceStatus NewTimeAttendanceStatus = _Map.Map<Entity.TimeAttendanceStatus>(TimeAttendanceStatus);

            NewTimeAttendanceStatus.CreationDate = DateTime.UtcNow;
            _unitofwork.timeAttendanceStatus.Create(NewTimeAttendanceStatus);
            _unitofwork.Complete();

            TimeAttendanceStatus.ID = NewTimeAttendanceStatus.ID;
            return Ok(TimeAttendanceStatus);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.TimeAttendanceStatus TimeAttendanceStatus)
        {


            var EntityTimeAttendanceStatus = _Map.Map<Entity.TimeAttendanceStatus>(TimeAttendanceStatus);
            _unitofwork.timeAttendanceStatus.Update(EntityTimeAttendanceStatus);
            _unitofwork.Complete();
            TimeAttendanceStatus = _Map.Map<DTO.TimeAttendanceStatus>(EntityTimeAttendanceStatus);
            return Ok(TimeAttendanceStatus);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.TimeAttendanceStatus TimeAttendanceStatus)
        {
            var EntityTimeAttendanceStatus = _unitofwork.timeAttendanceStatus.GetByID(TimeAttendanceStatus.ID);
            if (EntityTimeAttendanceStatus != null)
            {


                EntityTimeAttendanceStatus.IsDeleted = true;
                EntityTimeAttendanceStatus.DeleteDate = DateTime.UtcNow;
                EntityTimeAttendanceStatus.DeleteUserID = TimeAttendanceStatus.DeleteUserID;
                _unitofwork.Complete();
                var DTOTimeAttendanceStatus = _Map.Map<DTO.TimeAttendanceStatus>(EntityTimeAttendanceStatus);
                return Ok(DTOTimeAttendanceStatus);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
