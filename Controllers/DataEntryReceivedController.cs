using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.ApIncharge.DataEntryReceivedFunctions;

namespace InfoMgmtSys.Controllers
{
    public class DataEntryReceivedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddDataEntryReceived")]
        public IActionResult AddDataEntryRecieved([FromForm] Models.DataEntry.DataEntryReceived dataEntryReceived)
        {
            using var db = new AppDB();
            bool isExecuted = dataEntryReceived.AddDataEntryRecieved(db, dataEntryReceived);
            if (isExecuted) Console.WriteLine("insert success");
            return isExecuted ? Ok() : BadRequest();
        }
        [HttpGet("GetAllDataEntryRecieved")]
        public ActionResult<List<Models.DataEntry.DataEntryReceived>> GetAllDataEntryRecieved()
        {
            using var db = new AppDB();
            var list = Models.DataEntry.DataEntryReceived.GetAllDataEntryRecieved(db);
            return Ok(list);
        }
        [HttpPut("UpdateDataEntryRecievedApIncharge")]
        public IActionResult UpdateDataEntryRecieved([FromForm] UpdateDataEntryReceived updateDataEntryReceived)
        {
            using var db = new AppDB();
            bool isExecuted = updateDataEntryReceived.ExeUpdateDataEntryRecieved(db, updateDataEntryReceived);
            if (isExecuted) Console.WriteLine("Update Success");
            return isExecuted ? Ok() : BadRequest();
        }
        [HttpPost("AddDataEntryReceivedWarehouseman")]
        public IActionResult AddDataEntryReceivedWarehouseman([FromForm] Models.DataEntry.Warehouseman.AddDataEntryReceived ader)
        {
            using var db = new AppDB();
            bool isExecuted = ader.AddDataEntryReceivedWarehouseman(db, ader);
            if (isExecuted) Console.WriteLine("Insert Success");
            return isExecuted ? Ok(): BadRequest();

        }
        public class ReviewSheet
        {
            public int RR_no { get; set; }
        }
        [HttpPost("GetDataEntryReceivedReviewSheet")]
        public ActionResult<List<Models.DataEntry.Warehouseman.GetReviewSheet>> GetDataEntryReceivedReviewSheet([FromForm] ReviewSheet rs)
        {
            using var db = new AppDB();
            var list = Models.DataEntry.Warehouseman.GetReviewSheet.GetDataEntryReveivedReviewSheet(db, rs);
            return Ok(list);
        }
    }
}
