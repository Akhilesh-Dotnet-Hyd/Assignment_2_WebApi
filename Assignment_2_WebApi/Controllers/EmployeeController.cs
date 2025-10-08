using Assignment_2_WebApi.Models;
using Assignment_2_WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Assignment_2_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = _repository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("dept/{name}")]
        public IActionResult GetByDept(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employees = _repository.GetEmployeesByDept(name);
            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, new { message = "Employee Added Successfully.", data = employee });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.UpdateEmployee(employee);
            return Ok(new { message = "Employee Updated Successfully.", data = employee });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteEmployee(id);
            return Ok(new { message = "Employee Deleted Successfully." });

        }
    }
}
