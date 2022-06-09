using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PayrollAPI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required,StringLength(50)]
        public string RoleName { get; set; }

        [Required,StringLength(50)]
        public int RoleType { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required,StringLength(50)]
        public string RoleCode { get; set; }


        public virtual User _user { get; set; }
    }
}
