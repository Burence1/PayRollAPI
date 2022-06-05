using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Models
{
    public class PayrollContext : DbContext 
    {
        public PayrollContext(DbContextOptions<PayrollContext> options) :base(options)
        { }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
    }
}
