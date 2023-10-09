using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class User : BaseGet
    {
        [Required]
        [StringLength(150)]
        public string UserName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DeletDate { get; set; }
        public bool IsActive { get; set; }



        //public virtual ICollection<Employee> CreationUser_Employee { get; set; }
        //public virtual ICollection<Employee> ModifyUser_Employee { get; set; }
        //public virtual ICollection<Employee> DeleteUser_Employee { get; set; }

    }
}
