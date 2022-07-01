using EmployeeWebApp.Models;

namespace EmployeeWebApp.Services
{
    public interface IRepository
    {
        Employee GetEmployeeById(int id);
        Department GetDepartment(int id);
        Dictionary<string,int> GetEmployeeCountsByDepartment();
    }
}
