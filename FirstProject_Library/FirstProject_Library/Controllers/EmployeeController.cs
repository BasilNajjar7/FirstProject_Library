using FirstProject_Library.Data;
using FirstProject_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly ApplicationDbContext _dbcontext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Employee>>Get()
        {
            var employees = _dbcontext.Set<Employee>().ToList();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int id)
        {
            var employee = _dbcontext.Set<Employee>().Find(id);
            return (employee == null ? NotFound() : Ok(employee));
        }
        [HttpPost]
        [Route("")]
        public ActionResult<int> AddNewEmplyee(EmployeeReceive emp)
        {
            emp.Id = 0;
            Employee NewEmployee = new Employee
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                MyCategory = emp.MyCategory,
                Salary = emp.Salary
            };
            _dbcontext.Set<Employee>().Add(NewEmployee);
            _dbcontext.SaveChanges();
            return Ok(emp.Id);
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult UpdateEmplyee(EmployeeReceive emp)
        {
            var employee= _dbcontext.Set<Employee>().Find(emp.Id);
            if(employee == null)return NotFound();
            employee.Salary = emp.Salary;
            employee.MyCategory = emp.MyCategory;
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            _dbcontext.Set<Employee>().Update(employee);
            _dbcontext.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeletEmployee(int id)
        {
            var employee = _dbcontext.Set<Employee>().Find(id);
            if(employee == null)return NotFound();
            _dbcontext.Set<Employee>().Remove(employee);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}