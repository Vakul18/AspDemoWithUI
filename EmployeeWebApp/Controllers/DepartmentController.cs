using EmployeeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    [ApiController]
    [Route("department")]
    public class DepartmentController :ControllerBase
    {
        private readonly IRepository _repository;

        public DepartmentController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _repository.GetDepartment(id);
            if(department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpGet]
        [Route("employeecount")]
        public IActionResult employeeCount()
        {
            var countDictionary = _repository.GetEmployeeCountsByDepartment();
            return Ok(countDictionary);
        }
    }
}
