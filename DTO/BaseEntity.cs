using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public int? CreationUserID { get; set; }
        public DateTime? CreationDate { get; set; }



        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }


        public bool IsDeleted { get; set; } = false;
        public int? DeleteUserID { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
