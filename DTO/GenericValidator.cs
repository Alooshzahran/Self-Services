using FluentValidation;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GenericValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        private readonly IUnitofwork _UnitOfWork;

        public GenericValidator(IUnitofwork UnitOfWork)
        {
            When(e => e.ID == null || e.ID == 0, () =>
            {
                RuleFor(e => e.CreationDate).NotNull().WithErrorCode("1011");
                RuleFor(e => e.CreationUserID).NotNull().WithErrorCode("1011");
                When(e => e.CreationUserID != null, () =>
                {
                    RuleFor(x => x.CreationUserID).Must(IsUserIdExist).WithErrorCode("1023");
                });

            });

            When(e => e.ID > 0 && !e.IsDeleted, () =>
            {
                RuleFor(e => e.ModifyDate).NotNull().WithErrorCode("1011");
                RuleFor(e => e.ModifyUserID).NotNull().WithErrorCode("1011");
                When(e => e.ModifyUserID != null, () =>
                {
                    RuleFor(x => x.ModifyUserID).Must(IsUserIdExist).WithErrorCode("1023");
                });
            });

            When(e => e.ID > 0 && e.IsDeleted, () =>
            {
                RuleFor(e => e.DeleteDate).NotNull().WithErrorCode("1011");
                RuleFor(e => e.DeleteUserID).NotNull().WithErrorCode("1011");
                When(e => e.DeleteUserID != null, () =>
                {
                    RuleFor(x => x.DeleteUserID).Must(IsUserIdExist).WithErrorCode("1023");
                });
            });
            _UnitOfWork = UnitOfWork;
        }
        private bool IsUserIdExist(int? UserID)
        {
            bool Result = false;
            if (UserID > 0)
                Result = _UnitOfWork.user.GetByID(UserID ?? 0) != null;

            return Result;
        }
    }
}

