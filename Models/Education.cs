using System.ComponentModel.DataAnnotations;


namespace PayrollAPI.Models
{
    public class Education
    {
        [Key]
        public int InstitutionId { get; set; }

        [Required,StringLength(50)]
        public string InstitutionName { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
