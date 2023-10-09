using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class BaseEntity : BaseGet
    {
        public int? CreationUserID { get; set; }
        public virtual User? CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifyUserID { get; set; }
        public virtual User? ModifyUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public virtual User? DeleteUser { get; set; }
        public int? DeleteUserID { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
