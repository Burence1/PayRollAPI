using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAPI.Models
{
    public class EmployeeEducation
    {
        [Key]
        public int EducationHistId { get; set; }

        [Required, StringLength(50)]
        public string InstitutionName { get; set; }

        [Required, StringLength(50)]
        public string institutionCode {get; set; }

        [Required,StringLength(50)]
        public string joinDate { get; set; }

        [Required,StringLength(50)]
        public string endDate { get; set; }

        [Required, StringLength(50)]
        public string fieldOfStudy { get; set; }

        [Required,StringLength(50)]
        public string Score { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public EmployeeDetail employeeDetail { get; set; }

    }
}
