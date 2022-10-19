using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.Warehouseman.IssuanceDataEntry;
using InfoMgmtSys.Models.DataEntry.ApIncharge.IssuanceDataEntry;
using InfoMgmtSys.Models.DataEntry.AllAccess.IssuanceDataEntry;
using InfoMgmtSys.Security;

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
            var collectionOrders = new AddMultipleCollectionIdeOders();
            string exeResult = collectionOrders.ExeAddMultipleCollectionIdeOrders(addMultipleCollectionIdeOders);
            return ExeResultWithData(exeResult, addMultipleCollectionIdeOders);
        }
        [HttpPost("AddIdeWithOrders")]
        public IActionResult AddIdeWithOrders([FromBody] AddIdeWithOrders addIdeWithOrders)
        {
            string exeResult = addIdeWithOrders.ExeAddIdeWithOrders(addIdeWithOrders);
            return ExeResultWithData(exeResult, addIdeWithOrders);
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
        [HttpPut("UpdateIdeWithOrders")]
        public IActionResult ExeUpdateIdeWithOrders([FromBody] Models.DataEntry.ApIncharge.IssuanceDataEntry.UpdateIdeWithOrdersByMisNo updateIdeWithOrders)
        {
            using var db = new AppDB();
            string exeResult = updateIdeWithOrders.ExeUpdateIdeWithOrders(updateIdeWithOrders);
            return ExeResultWithData(exeResult, updateIdeWithOrders);
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
            string exeResult = updateAllCollectionOfIdeOrderByEntryNo.ExeUpdateAllCollectionOfIdeOrderByEntryNo(updateAllCollectionOfIdeOrderByEntryNo);
            return ExeResultWithData(exeResult, updateAllCollectionOfIdeOrderByEntryNo);
        }
        [HttpPut("UpdateAllIdeWithOrders")]
        public IActionResult UpdateAllIdeWithOrders([FromBody] UpdateAllIdeWithOrdersByMisNo updateAllIdeWithOrdersByMisNo)
        {
            dynamic exeResult = updateAllIdeWithOrdersByMisNo.ExeUpdateIdeWithOrders(updateAllIdeWithOrdersByMisNo);
            return ExeResultWithDataGet(exeResult);
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
        public IActionResult ExeGetCollectionOfIdeOrdersSummary([FromQuery] GetCollectionOfIdeOrdersSummary.GetCollectionOfIdeOrdersSummaryParams getCollectionOfIdeOrdersSummaryParams)
        {
            using var db = new AppDB();
            var list = GetCollectionOfIdeOrdersSummary.ExeGetCollectionOfIdeOrdersSummary(db, getCollectionOfIdeOrdersSummaryParams);
            return ExeResultWithDataGet(list);

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
        public IActionResult ExeGetAllIdeWithOrdersByCurrentMonth()
        {
            var e = GetAllIdeWithOrdersByCurrentMonth.ExeGetAllIdeWithOrdersByCurrentMonth();
            return ExeResultWithDataGet(e);
        }
        [HttpGet("GetAllIdeWithOrdersBySearch")]
        public IActionResult ExeGetAllIdeWithOrdersBySearch([FromQuery] GetIdeWithOrdersBySearch.SearchParam searchParam )
        {
            var e = GetIdeWithOrdersBySearch.ExeGetAllIdeWithOrdersBySearch(searchParam);
            return ExeResultWithDataGet(e);
        }
        [HttpGet("GetAllIdeWithOrdersAndCollectionByCurrentMonth")]
        public IActionResult ExeGetAllIdeWithOrdersAndCollectionByCurrentMonth()
        {
            var e = GetAllIdeWithOrdersAndCollectionByCurrentMonth.ExeGetAllIdeWithOrdersByCurrentMonth();
            return ExeResultWithDataGet(e);
        }
        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
        private IActionResult ExeResultWithDataGet(dynamic data)
        {
            var dType = ((object)data).GetType().Name;
            if (dType == "String")
            {
                return BadRequest( RequestResult.ExeResponse("Error", data));
            }
            else
            {
                return Ok(RequestResult.ExeResponse("Success", data));
            }
        }

        private IActionResult ExeResultWithData(string result, dynamic data)
        {
            if (result == "Success")
            {
                return Ok(RequestResult.ExeResponse(result, data));
            }
            else
            {
                return BadRequest(RequestResult.ExeResponse("Error", result));
            }

        }
    }
}
