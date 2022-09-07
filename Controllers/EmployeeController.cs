using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromForm] Models.Employees.Employee employee)
        {
            using var db = new AppDB();
            bool isExecuted = employee.AddEmployee(db);
            if (isExecuted) Console.WriteLine("Insert Success");
            return isExecuted ? Ok() : BadRequest();
        }
    }
}
