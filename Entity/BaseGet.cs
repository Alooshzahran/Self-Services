
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class BaseGet : IBaseGet
    {
        [Key]
        public int ID { get; set; }
        public bool? IsDeleted { get; set; }
    }
}