using Microsoft.EntityFrameworkCore;

namespace PayrollAPI.Models
{
    public class PayrollContext : DbContext 
    {
        public PayrollContext(DbContextOptions<PayrollContext> options) :base(options)
        { }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }

        public DbSet<Education> educations { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<User>? users { get; set; }

        //public DbSet<(EmployeeDetail, EmployeeEducation)> EmployeeEducations { get; set; }
    }
}
