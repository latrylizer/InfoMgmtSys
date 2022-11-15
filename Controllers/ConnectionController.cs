using Microsoft.AspNetCore.Authorization;
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
            try
            {
                using var db = new AppDB();
                return Ok(db);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
