using EmployeeWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repo;

        public EmployeeController(IRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if(employee == null)
                return NotFound();
            return Ok(employee);
        }
    }
}
