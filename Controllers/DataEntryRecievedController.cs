using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.DataEntryReceivedFunctions;

namespace InfoMgmtSys.Controllers
{
    public class DataEntryRecievedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("Add Data Entry Received")]
        public IActionResult AddDataEntryRecieved([FromForm] Models.DataEntry.DataEntryReceived dataEntryReceived)
        {
            using var db = new AppDB();
            bool isExecuted = dataEntryReceived.AddDataEntryRecieved(db, dataEntryReceived);
            if (isExecuted) Console.WriteLine("insert success");
            return isExecuted ? Ok() : BadRequest();
        }
        [HttpGet("Get All Data Entry Recieved")]
        public ActionResult<List<Models.DataEntry.DataEntryReceived>> GetAllDataEntryRecieved()
        {
            using var db = new AppDB();
            var list = Models.DataEntry.DataEntryReceived.GetAllDataEntryRecieved(db);
            return Ok(list);
        }
        [HttpPut("UpdateDataEntryRecieved")]
        public IActionResult UpdateDataEntryRecieved([FromForm] UpdateDataEntryRecieved updateDataEntryRecieved)
        {
            using var db = new AppDB();
            bool isExecuted = updateDataEntryRecieved.ExeUpdateDataEntryRecieved(db, updateDataEntryRecieved);
            if (isExecuted) Console.WriteLine("Update Success");
            return isExecuted ? Ok() : BadRequest();
        }
    }
}
