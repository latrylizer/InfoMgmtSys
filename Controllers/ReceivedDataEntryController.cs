using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.Warehouseman.ReceivedDataEntry;
using InfoMgmtSys.Models.DataEntry.ApIncharge.ReceivedDataEntry;
using InfoMgmtSys.Models.DataEntry.AllAccess.ReceivedDataEntry;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Authorization;
using InfoMgmtSys.Models.Logs;


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
        [Authorize]
        [HttpPost("AddRdeWithOrders")]
        public IActionResult AddRdeWithOrders([FromBody] AddRdeWithOrders addRdeWithOrders)
        {
            try
            {
                string isExecuted = addRdeWithOrders.ExeAddRdeWithOrders(addRdeWithOrders, this.HttpContext);
               
                return ExeResultWithData(isExecuted, addRdeWithOrders);

            }
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
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
        //[Authorize]
        [HttpPut("UpdateRdeWithOrders")]
        public IActionResult UpdateRdeWithOrders([FromBody] UpdateRdeWithOrdersByRrNo updateRdeWithOrdersByRrNo)
        {
            try
            {
                string isExecuted = updateRdeWithOrdersByRrNo.ExeUpdateRdeWithOrders(updateRdeWithOrdersByRrNo, this.HttpContext);
               // AddLogs.ExeAddLogs(updateRdeWithOrdersByRrNo, this.HttpContext, "Receiving", updateRdeWithOrdersByRrNo.RR_no, "Update");
                return ExeResultWithData(isExecuted, updateRdeWithOrdersByRrNo);

            }
            catch (Exception ex)
            {
                return ExeResultWithData("Error", ex.Message);
            }
        }
        public class updateLog
        {
            public string? resultText { get; set; }
            public string? errorMessage { get; set; }
            public dynamic? inputed { get; set; }
            
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
        [Authorize]
        [HttpPut("UpdateAllRdeWithOrdersByRrNo")]
        public IActionResult UpdateAllRdeWithOrdersByRrNo([FromBody] UpdateAllRdeWithOrdersByRrNo updateAllRdeWithOrdersByRrNo)
        {
            try {
                var isExecuted = updateAllRdeWithOrdersByRrNo.ExeUpdateAllRdeWithOrdersByRrNo(updateAllRdeWithOrdersByRrNo, this.HttpContext);
                return ExeResultWithDataGet(isExecuted);
            }
            catch(Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
            
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
        [Authorize]
        [HttpGet("GetRdeSummaryReport")]
        public IActionResult ExeGetRdeOrderByRrNo([FromQuery] GetRdeSummaryReport.GetRdeSummaryReportParams getRdeSummaryReportParams)
        {
            try
            {
                using var db = new AppDB();
                var list = GetRdeSummaryReport.ExeGetRdeSummaryReport(getRdeSummaryReportParams);
                return ExeResultWithDataGet(list);
            }
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
            
        }
        [Authorize]
        [HttpGet("GetRdeSummaryReportBySearch")]
        public IActionResult ExeGetRdeSummaryReportBySearch([FromQuery] GetRdeSummaryReportBySearch.GetRdeSummaryReportBySearchParams getRdeSummaryReportBySearchParams)
        {
            try
            {
                var list = GetRdeSummaryReportBySearch.ExeGetRdeSummaryReportBySearch(getRdeSummaryReportBySearchParams);
                return ExeResultWithDataGet(list);
            }
            catch (Exception ex)
            {
                return ExeResultWithDataGet(ex.Message);
            }
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
        [Authorize]
        [HttpGet("GetAllRdeWithOrdersCurrentMonth")]
        public IActionResult ExeGetAllRdeWithOrdersCurrentMonth()
        {
            try
            {
                var e = GetAllRdeWithOrdersCurrentMonth.ExeGetAllRdeWithOrdersCurrentMonth();
                return ExeResultWithDataGet(e);
            }
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
           
        }
        [Authorize]
        [HttpGet("GetAllRdeWithOrdersBySearch")]
        public IActionResult ExeGetAllRdeWithOrdersBySearch([FromQuery] GetAllRdeWithOrdersBySearch.SearchParam searchParam)
        {
            try
            {
                if(searchParam.Search == null)
                {
                    return BadRequest(RequestResult.ExeResponse("Error", searchParam));
                }
                var e = GetAllRdeWithOrdersBySearch.ExeGetAllRdeWithOrdersBySearch(searchParam);
                return ExeResultWithDataGet(e);
            }
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
            
        }


        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
        private IActionResult ExeResultWithDataGet(dynamic data)
        {
            var dType = ((object)data).GetType().Name;
            if(dType == "String")
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
        private IActionResult ExeResultIsNull(dynamic data)
        {
            return BadRequest(RequestResult.ExeResponse("Error", data));
        }

    }
}
