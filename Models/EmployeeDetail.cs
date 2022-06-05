using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAPI.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int EmployeeNo { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string MiddleName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required,StringLength(50)]
        public string Citizenship { get; set; }

        [Required, StringLength(13)]
        public string PhoneNumber { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public int IdNo { get; set; }

        [Required, StringLength(50)]
        public string KRANo { get; set; }

        [Required, StringLength(50)]
        public string NHIFNo { get; set; }

        [Required, StringLength(50)]
        public string NSSFNo { get; set; }

        [Required]
        [Column(TypeName = "Decimal (38,2)")]
        public Decimal GrossPay { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int NumberOfChildren { get; set; }

        [StringLength(50)]
        public string MaritalStatus { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int EmployerCode { get; set; }

        [Required]
        public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
