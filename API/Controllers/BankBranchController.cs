using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBranchController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public BankBranchController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.BankBranch> EntityBankBranch = _unitofwork.branch.GetAll().ToList();
            var DtoBankBranch = _Map.Map<List<DTO.BankBranch>>(EntityBankBranch);
            return Ok(DtoBankBranch);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityBankBranchType = _unitofwork.branch.GetByID(Id);
            var DTOBankBranchType = _Map.Map<DTO.BankBranch>(EntityBankBranchType);

            return Ok(DTOBankBranchType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.BankBranch BankBranch)
        {
           
            var NewBankBranch = _Map.Map<Entity.BankBranch>(BankBranch);

            NewBankBranch.CreationDate = DateTime.UtcNow;
            _unitofwork.branch.Create(NewBankBranch);
            _unitofwork.Complete();

            BankBranch.ID = NewBankBranch.ID;
            return Ok(BankBranch);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.BankBranch BankBranch)
        {


            Entity.BankBranch EntityBankBranch = _Map.Map<Entity.BankBranch>(BankBranch);
            _unitofwork.branch.Update(EntityBankBranch);
            _unitofwork.Complete();
            BankBranch = _Map.Map<DTO.BankBranch>(EntityBankBranch);
            return Ok(BankBranch);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.BankBranch BankBranch)
        {
            var EntityBankBranch = _unitofwork.branch.GetByID(BankBranch.ID);
            if (EntityBankBranch != null)
            {


                EntityBankBranch.IsDeleted = true;
                EntityBankBranch.DeleteDate = DateTime.UtcNow;
                EntityBankBranch.DeleteUserID = BankBranch.DeleteUserID;
                _unitofwork.Complete();
                var DTOBankBranch = _Map.Map<DTO.BankBranch>(EntityBankBranch);
                return Ok(DTOBankBranch);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
