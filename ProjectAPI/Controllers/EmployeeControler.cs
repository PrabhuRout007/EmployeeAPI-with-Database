using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControler : ControllerBase
    {
  
        private readonly ProjectContext _context;

        public EmployeeControler(ProjectContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<EmployeeClass>>> Add([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
           
        }
        [HttpGet]

        public async Task<ActionResult<List<EmployeeClass>>> GetAll()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<List<EmployeeClass>>> GetById([FromHeader] int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
         
            return Ok(employee);
        }

        [HttpPut]

        public async Task<ActionResult<List<EmployeeClass>>> Update(EmployeeClass request)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
          
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.Place = request.Place;

            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<List<EmployeeClass>>> Delete([FromHeader] int  Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (Id == null)
            {
                return BadRequest("Employee Not Found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
