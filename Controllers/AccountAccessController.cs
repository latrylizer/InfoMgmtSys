using Microsoft.AspNetCore.Mvc;

namespace InfoMgmtSys.Controllers
{
    public class AccountAccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
