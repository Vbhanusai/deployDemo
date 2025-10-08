using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreCollectonCRUD.Models;
using WebApiCoreCollectonCRUD.Repository;

namespace WebApiCoreCollectonCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _repo = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("id/{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var emp = _repo.GetById(id);
            if (emp == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            return Ok(emp);
        }
        [HttpGet("dept")]
        public IActionResult GetEmployeeByDept([FromQuery] string dept)
        {
            //var employees = _repo.GetByDept(dept);
            return Ok(_repo.GetByDept(dept));
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(emp);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.Id }, emp);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeModel emp)
        {
            var existingEmp = _repo.GetById(id);
            if (existingEmp == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            if (ModelState.IsValid)
            {
                _repo.Update(id, emp);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPatch("update-email")]
        public IActionResult UpdateEmployeeEmail(int id, [FromBody] string email)
        {
            var existingEmp = _repo.GetById(id);
            if (existingEmp == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            if (ModelState.IsValid)
            {
                _repo.UpdateEmail(id, email);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmp = _repo.GetById(id);
            if (existingEmp == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }
            _repo.Delete(id);
            return NoContent();
        }
        [HttpHead]
        public IActionResult Head()
        {
            var count = _repo.GetAll().Count();
            Response.Headers.Add($"{count}", count.ToString());
            return Ok();
        }
        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "Get,Post,Put,Patch,Delete,Head");
            return NoContent();
        }
    }
}
