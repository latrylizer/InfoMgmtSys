using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Controllers
{
    public class ConnectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetConnection")]
        public ActionResult GetConnection()
        {
            using var db = new AppDB();
            return Ok();
        }
    }
}
