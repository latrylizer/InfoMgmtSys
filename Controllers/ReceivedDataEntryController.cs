using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry;
using InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry;
using InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry;


namespace InfoMgmtSys.Controllers
{
    public class ReceivedDataEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddRde")]
        public IActionResult AddRde([FromForm] AddRde addRde)
        {
            using var db = new AppDB();
            bool isExecuted = addRde.ExeAddRde(db, addRde);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddRdeOrders")]
        public IActionResult AddRdeOrders([FromForm] AddRdeOrders addRdeOrders)
        {
            using var db = new AppDB();
            bool isExecuted = addRdeOrders.ExeAddRdeOrders(db, addRdeOrders);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateRde")]
        public IActionResult UpdateRde([FromForm] UpdateRde updateRde)
        {
            using var db = new AppDB();
            bool isExecuted = updateRde.ExeUpdateRde(db, updateRde);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateRdeOrders")]
        public IActionResult UpdateRdeOrders([FromForm] UpdateRdeOrders updateRdeOrders)
        {
            using var db = new AppDB();
            bool isExecuted = updateRdeOrders.ExeUpdateRdeOrders(db, updateRdeOrders);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAllRdRyRrNo")]
        public IActionResult UpdateAllRde([FromForm] UpdateAllRdeByRrNo updateAllRdeByRrNo)
        {
            using var db = new AppDB();
            bool isExecuted = updateAllRdeByRrNo.ExeUpdateAllRdeByRrNo(db, updateAllRdeByRrNo);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAllRdeOrdersByEntryNo")]
        public IActionResult UpdateAllRdeOrders([FromForm] UpdateAllRdeOrderEntryNo updateAllRdeOrderEntryNo)
        {
            using var db = new AppDB();
            bool isExecuted = updateAllRdeOrderEntryNo.ExeUpdateAllRdeOrderEntryNo(db, updateAllRdeOrderEntryNo);
            return ExeResult(isExecuted);
        }
       [HttpGet("GetRdeByRrNo")]
        public ActionResult<List<GetRdeByRrNo>> ExeGetRdeByRrNo([FromQuery] GetRdeByRrNo.GetRdeByRrNoParams getRdeByRrNoParams )
        {
            using var db = new AppDB();
            var list = GetRdeByRrNo.ExeGetRdeByRrNo(db, getRdeByRrNoParams);
            return list;          
        }
        [HttpGet("GetRdeOrderByRrNo")]
        public ActionResult<List<GetRdeOrderByRrNo>> ExeGetRdeOrderByRrNo([FromQuery] GetRdeOrderByRrNo.GetRdeOrderByRrNoParams getRdeOrderByRrNoParams)
        {
            using var db = new AppDB();
            var list = GetRdeOrderByRrNo.ExeGetRdeOrderByRrNo(db, getRdeOrderByRrNoParams);
            return list;
        }
        [HttpGet("GetRdeSummaryReport")]
        public ActionResult<List<GetRdeSummaryReport>> ExeGetRdeOrderByRrNo([FromQuery] GetRdeSummaryReport.GetRdeSummaryReportParams getRdeSummaryReportParams)
        {
            using var db = new AppDB();
            var list = GetRdeSummaryReport.ExeGetRdeSummaryReport(db, getRdeSummaryReportParams);
            return list;
        }
        [HttpGet("GetLatestRrNo")]
        public ActionResult<List<GetLatestRrNo>> ExeGetLatestRrNo()
        {
            using var db = new AppDB();
            var list = GetLatestRrNo.ExeGetLatestRrNo(db);
            return list;
        }
        [HttpGet("GetIncompleteRde")]
        public ActionResult<List<GetIncompleteRde>> ExeGetIncompleteRde()
        {
            using var db = new AppDB();
            var list = GetIncompleteRde.ExeGetIncompleteRde(db);
            return list;
        }


        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
       
    }
}
