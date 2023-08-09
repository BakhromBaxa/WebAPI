using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ICSVService _csvService;

        public EmployeeController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("read-employees-csv")]
        public IActionResult GetEmployeeCSV([FromForm] IFormFileCollection file)
        {
            var employees = _csvService.ReadCSV<Employee>(file[0].OpenReadStream());

            return Ok(employees);
        }
    }
}
