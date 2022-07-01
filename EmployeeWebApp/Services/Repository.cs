using EmployeeWebApp.Models;
using System.Linq;

namespace EmployeeWebApp.Services
{
    public class Repository : IRepository
    {
        private readonly ApiContext _apiContext;

        public Repository(ApiContext apiContext)
        {
            this._apiContext = apiContext;
        }

        Department IRepository.GetDepartment(int id)
        {
            return _apiContext.Departments.Where(d => d.Id == id).FirstOrDefault();
        }

        Employee IRepository.GetEmployeeById(int id)
        {
            return _apiContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        Dictionary<string, int> IRepository.GetEmployeeCountsByDepartment()
        {
            var result = (from dept in _apiContext.Departments join emp in _apiContext.Employees on dept.Id equals emp.DepartmentId select new { DepartmentName = dept.Name, EmployeeId = emp.Id })
                .GroupBy(x => x.DepartmentName).Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                }).ToDictionary(x => x.Name, x => x.Count);

            //var result1 = _apiContext.Departments.GroupJoin(_apiContext.Employees, d => d.Id, e => e.DepartmentId, (d, eG) => new
            //{
            //    DepartmentName = d.Name,
            //    Count = eG.Count()
            //});

            //var result = result1.ToDictionary(x => x.DepartmentName, x => x.Count);

            return result;
        }
    }
}
