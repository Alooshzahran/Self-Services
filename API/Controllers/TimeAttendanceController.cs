using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeAttendanceController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public TimeAttendanceController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.TimeAttendance> EntityTimeAttendance = _unitofwork.timeAttendance.GetAll().ToList();
            var DtoTimeAttendance = _Map.Map<List<DTO.TimeAttendance>>(EntityTimeAttendance);
            return Ok(DtoTimeAttendance);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityTimeAttendanceType = _unitofwork.timeAttendance.GetByID(Id);
            var DTOTimeAttendanceType = _Map.Map<DTO.TimeAttendance>(EntityTimeAttendanceType);

            return Ok(DTOTimeAttendanceType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.TimeAttendance TimeAttendance)
        {

            Entity.TimeAttendance NewTimeAttendance = _Map.Map<Entity.TimeAttendance>(TimeAttendance);

            NewTimeAttendance.CreationDate = DateTime.UtcNow;
            _unitofwork.timeAttendance.Create(NewTimeAttendance);
            _unitofwork.Complete();

            TimeAttendance.ID = NewTimeAttendance.ID;
            return Ok(TimeAttendance);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.TimeAttendance TimeAttendance)
        {


            var EntityTimeAttendance = _Map.Map<Entity.TimeAttendance>(TimeAttendance);
            _unitofwork.timeAttendance.Update(EntityTimeAttendance);
            _unitofwork.Complete();
            TimeAttendance = _Map.Map<DTO.TimeAttendance>(EntityTimeAttendance);
            return Ok(TimeAttendance);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.TimeAttendance TimeAttendance)
        {
            var EntityTimeAttendance = _unitofwork.timeAttendance.GetByID(TimeAttendance.ID);
            if (EntityTimeAttendance != null)
            {


                EntityTimeAttendance.IsDeleted = true;
                EntityTimeAttendance.DeleteDate = DateTime.UtcNow;
                EntityTimeAttendance.DeleteUserID = TimeAttendance.DeleteUserID;
                _unitofwork.Complete();
                var DTOTimeAttendance = _Map.Map<DTO.TimeAttendance>(EntityTimeAttendance);
                return Ok(DTOTimeAttendance);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTimeAttendanceWhereEmpId(int Id)
        {
            var EntityTimeAttendance = _unitofwork.timeAttendance.GetTimeAttendanceWhereEmpId(Id);
            var DTOTimeAttendanceType = _Map.Map<DTO.TimeAttendance>(EntityTimeAttendance);
            return Ok(DTOTimeAttendanceType);
        } 
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDifferentofTime()
        {
            System.Globalization.CultureInfo ci =
           System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek today = DateTime.Now.DayOfWeek;
            DateTime sow = DateTime.Now.AddDays(-(today - fdow)).Date;
            var EntityTimeAttendance = _unitofwork.timeAttendance.GetAll();
            var DTOTimeAttendanceType = _Map.Map<DTO.TimeAttendance>(EntityTimeAttendance);
            return Ok(DTOTimeAttendanceType);
        }
    }
}
