using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShiftType : BaseEntity
    {
        public string ShiftCode { get; set; }
        public string ShiftTypeName { get; set; }
        public string ShiftTypeNameAR { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }


    }
}
