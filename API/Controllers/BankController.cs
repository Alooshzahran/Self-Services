using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public BankController(IUnitofwork unitofwork, IMapper map)
        {
            _unitofwork = unitofwork;
            _Map = map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.Bank> EntityBank = _unitofwork.bank.GetAll().ToList();
            var DtoBank = _Map.Map<List<DTO.Bank>>(EntityBank);
            return Ok(DtoBank);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityBankType = _unitofwork.bank.GetByID(Id);
            var DTOBankType = _Map.Map<DTO.Bank>(EntityBankType);

            return Ok(DTOBankType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.Bank Bank)
        {

            Entity.Bank NewBank = _Map.Map<Entity.Bank>(Bank);

            NewBank.CreationDate = DateTime.UtcNow;
            _unitofwork.bank.Create(NewBank);
            _unitofwork.Complete();

            Bank.ID = NewBank.ID;
            return Ok(Bank);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.Bank Bank)
        {


            var EntityBank = _Map.Map<Entity.Bank>(Bank);
            _unitofwork.bank.Update(EntityBank);
            _unitofwork.Complete();
            Bank = _Map.Map<DTO.Bank>(EntityBank);
            return Ok(Bank);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.Bank Bank)
        {
            var EntityBank = _unitofwork.bank.GetByID(Bank.ID);
            if (EntityBank != null)
            {


                EntityBank.IsDeleted = true;
                EntityBank.DeleteDate = DateTime.UtcNow;
                EntityBank.DeleteUserID = Bank.DeleteUserID;
                _unitofwork.Complete();
                var DTOBank = _Map.Map<DTO.Bank>(EntityBank);
                return Ok(DTOBank);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
