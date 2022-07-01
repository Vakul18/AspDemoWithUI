using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApp.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            //Departments.AddRange(new Department { Id = 1, Name = "HR" }, new Department { Id = 2, Name = "IT" });

            //Employees.AddRange(new Employee { Name = "Changu", Id = 1, DepartmentId = 1 },
            //    new Employee { Name = "Mangu", Id = 2, DepartmentId = 1 },
            //    new Employee { Name = "Tina", Id = 3, DepartmentId = 2 },
            //    new Employee { Name = "Ina", Id = 4, DepartmentId = 2 },
            //    new Employee { Name = "Meena", Id = 5, DepartmentId = 2 },
            //    new Employee { Name = "Deeka", Id = 6, DepartmentId = 2 }
            //    );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
               
            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(p => p.DepartmentId);

          


        }
    }
}
