using EmployeeWebApp.Models;

namespace EmployeeWebApp
{
    public class DataSeed
    {
        private readonly ApiContext _apiContext;

        public DataSeed(ApiContext apiContext)
        {
            this._apiContext = apiContext;
        }

        public void Initialize()
        {
            _apiContext.Departments.AddRange(new Department { Id = 1, Name = "HR" }, new Department { Id = 2, Name = "IT" });

            _apiContext.Employees.AddRange(new Employee { Name = "Changu", Id = 1, DepartmentId = 1 },
                new Employee { Name = "Mangu", Id = 2, DepartmentId = 1 },
                new Employee { Name = "Tina", Id = 3, DepartmentId = 2 },
                new Employee { Name = "Ina", Id = 4, DepartmentId = 2 },
                new Employee { Name = "Meena", Id = 5, DepartmentId = 2 },
                new Employee { Name = "Deeka", Id = 6, DepartmentId = 2 }
                );
            _apiContext.SaveChanges();
        }
    }
}
