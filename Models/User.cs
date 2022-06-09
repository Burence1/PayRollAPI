using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PayrollAPI.Models
{
    public class User
    {
        [ForeignKey("Role")]
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName Is Required!"), StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required,StringLength(50)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User Email Is Required!"), StringLength(50)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage ="PassWord Is Required!")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required,StringLength(25)]
        public string UserPhone { get; set; }

        [Required]
        public Boolean Logged { get; set; }

        [Required()]
        public Boolean IsLocked { get; set; }
        
        [Required()]
        public Boolean IsDeleted { get; set; }

        [Required()]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required()]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }

        public virtual Role Role { get; set; }

    }
}
