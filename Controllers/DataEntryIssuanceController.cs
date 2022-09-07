using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.DataEntryReceivedFunctions;

namespace InfoMgmtSys.Controllers
{
    public class DataEntryIssuanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Add Data Entry Issuance")]
        public IActionResult AddDataEntryIssuance([FromForm] Models.DataEntry.DataEntryIssuance dei)
        {
            using var db = new AppDB();
            bool isExecuted = dei.AddDataEntryRecieved(db, dei);
            if (isExecuted) Console.WriteLine("insert success");
            return isExecuted ? Ok() : BadRequest();
        }
        [HttpGet("Get All Data Entry Issuance")]
        public ActionResult<List<Models.DataEntry.DataEntryIssuance>> GetAllDataEntryIssuance()
        {
            using var db = new AppDB();
            var list = Models.DataEntry.DataEntryIssuance.GetAllDataEntryIssuance(db);
            return list;
        }
        [HttpPut("UpdateDataEntryIssuance")]
        public IActionResult UpdateDataEntryIssuance([FromForm]UpdateDataEntryIssuance updateDataEntryIssuance) 
        {
            using var db = new AppDB();
            bool isExecuted = updateDataEntryIssuance.ExeUpdateDataEntryIssuance(db, updateDataEntryIssuance);
            return isExecuted? Ok(): BadRequest();
        }
    }
}
