using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry;
using InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry;
using InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry;

namespace InfoMgmtSys.Controllers
{
    public class IssuanceDataEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddIde")]
        public IActionResult AddIde([FromForm] AddIde addIde)
        {
            using var db = new AppDB();
            bool isExecuted = addIde.ExeAddIde(db, addIde);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }

        [HttpPost("AddIdeOrders")]
        public IActionResult AddIdeOrders([FromForm] AddIdeOrders addIdeOrders)
        {
            using var db = new AppDB();
            bool isExecuted = addIdeOrders.ExeAddIdeOrders(db, addIdeOrders);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddCollectionIdeOrders")]
        public IActionResult AddCollectionIdeOrders([FromForm] AddCollectionIdeOrders addCollectionIdeOrders)
        {
            using var db = new AppDB();
            bool isExecuted = addCollectionIdeOrders.ExeAddCollectionIdeOrders(db, addCollectionIdeOrders);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddMultipleCollectionIdeOrders")]
        public IActionResult AddMultipleCollectionIdeOrders([FromBody] List<AddMultipleCollectionIdeOders> addMultipleCollectionIdeOders)
        {
            using var db = new AppDB();
            var collectionOrders = new AddMultipleCollectionIdeOders();
            bool isExecuted = collectionOrders.ExeAddMultipleCollectionIdeOrders(db, addMultipleCollectionIdeOders);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddIdeWithOrders")]
        public IActionResult AddIdeWithOrders([FromBody] AddIdeWithOrders addIdeWithOrders)
        {
            using var db = new AppDB();
            bool isExecuted = addIdeWithOrders.ExeAddIdeWithOrders(db, addIdeWithOrders);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }


        [HttpPut("UpdateIde")]
        public IActionResult UpdateIde([FromForm] UpdateIde updateIde)
        {
            using var db = new AppDB();
            bool isExecuted = updateIde.ExeUpdateIde(db, updateIde);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateIdeOrders")]
        public IActionResult UpdateIde([FromForm] UpdateIdeOrders updateIdeOrders)
        {
            using var db = new AppDB();
            bool isExecuted = updateIdeOrders.ExeUpdateIdeOrders(db, updateIdeOrders);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAllIdeByMisNo")]
        public IActionResult UpdateAllIdeByMisNo([FromForm] UpdateAllIdeByMisNo updateAllIdeByMisNo)
        {
            using var db = new AppDB();
            bool isExecuted = updateAllIdeByMisNo.ExeUpdateAllIdeByMisNo(db, updateAllIdeByMisNo);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAllIdeOrderByEntryNo")]
        public IActionResult UpdateAllIdeOrderByEntryNo([FromForm] UpdateAllIdeOrderByEntryNo updateAllIdeOrderByEntryNo)
        {
            using var db = new AppDB();
            bool isExecuted = updateAllIdeOrderByEntryNo.ExeUpdateAllIdeOrderByEntryNo(db, updateAllIdeOrderByEntryNo);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAllCollectionOfIdeOrderByEntryNo")]
        public IActionResult UpdateAllCollectionOfIdeOrderByEntryNo([FromForm] UpdateAllCollectionOfIdeOrderByEntryNo updateAllCollectionOfIdeOrderByEntryNo)
        {
            using var db = new AppDB();
            bool isExecuted = updateAllCollectionOfIdeOrderByEntryNo.ExeUpdateAllCollectionOfIdeOrderByEntryNo(db, updateAllCollectionOfIdeOrderByEntryNo);
            db.Exeresult(isExecuted);
            return ExeResult(isExecuted);
        }
        [HttpGet("GetIdeByMisNo")]
        public ActionResult<List<GetIdeByMisNo>> ExeGetIdeByMisNo([FromQuery] GetIdeByMisNo.GetIdeByMisNoParams getIdeByMisNo)
        {
            using var db = new AppDB();
            var list = GetIdeByMisNo.ExeGetIdeByMisNo(db, getIdeByMisNo);
            return list;
        }
        [HttpGet("GetLatestIdeMisNo")]
        public ActionResult<List<GetLatestIdeMisNo>> ExeGetLatestIdeMisNo()
        {
            using var db = new AppDB();
            Object obj = new object();
            var list = GetLatestIdeMisNo.ExeGetLatestIdeMisNo(db, obj);
            return list;
        }
        [HttpGet("GetCollectionOfIdeOrdersSummary")]
        public ActionResult<List<GetCollectionOfIdeOrdersSummary>> ExeGetCollectionOfIdeOrdersSummary([FromQuery] GetCollectionOfIdeOrdersSummary.GetCollectionOfIdeOrdersSummaryParams getCollectionOfIdeOrdersSummaryParams)
        {
            using var db = new AppDB();
            var list = GetCollectionOfIdeOrdersSummary.ExeGetCollectionOfIdeOrdersSummary(db, getCollectionOfIdeOrdersSummaryParams);
            return list;
        }
        [HttpGet("GetIncompleteIde")]
        public ActionResult<List<GetIncompleteIde>> ExeGetIncompleteIde()
        {
            using var db = new AppDB();
            object obj = new object();
            var list = GetIncompleteIde.ExeGetIncompleteIde(db, obj);
            return list;
        }
        [HttpGet("GetAllIdeWithOrdersByCurrentMonth")]
        public ActionResult<List<GetAllIdeWithOrdersByCurrentMonth>> ExeGetAllIdeWithOrdersByCurrentMonth()
        {
            return GetAllIdeWithOrdersByCurrentMonth.ExeGetAllIdeWithOrdersByCurrentMonth();
        }
        [HttpGet("GetAllIdeWithOrdersAndCollectionByCurrentMonth")]
        public ActionResult<List<GetAllIdeWithOrdersAndCollectionByCurrentMonth>> ExeGetAllIdeWithOrdersAndCollectionByCurrentMonth()
        {
            return GetAllIdeWithOrdersAndCollectionByCurrentMonth.ExeGetAllIdeWithOrdersByCurrentMonth();
        }
        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
    }
}
