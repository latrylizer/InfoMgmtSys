using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.DataEntry.ApIncharge.DataEntryReceivedFunctions;
using InfoMgmtSys.Models.DataEntry.Warehouseman;
namespace InfoMgmtSys.Controllers
{
    public class DataEntryIssuanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddDataEntryIssuance")]
        public IActionResult AddDataEntryIssuance([FromForm] Models.DataEntry.DataEntryIssuance dei)
        {
            using var db = new AppDB();
            bool isExecuted = dei.AddDataEntryRecieved(db, dei);
            if (isExecuted) Console.WriteLine("insert success");
            return isExecuted ? Ok() : BadRequest();
        }
        [HttpGet("GetAllDataEntryIssuance")]
        public ActionResult<List<Models.DataEntry.DataEntryIssuance>> GetAllDataEntryIssuance()
        {
            using var db = new AppDB();
            var list = Models.DataEntry.DataEntryIssuance.GetAllDataEntryIssuance(db);
            return list;
        }
        [HttpPut("UpdateDataEntryIssuanceApIncharge")]
        public IActionResult UpdateDataEntryIssuance([FromForm]UpdateDataEntryIssuance updateDataEntryIssuance) 
        {
            using var db = new AppDB();
            bool isExecuted = updateDataEntryIssuance.ExeUpdateDataEntryIssuance(db, updateDataEntryIssuance);
            return isExecuted? Ok(): BadRequest();
        }
        [HttpPost("AddDataEntryIssuanceWarehouseman")]
        public IActionResult AddDataEntryIssuanceWarehouseman([FromForm]AddDataEntryIssuance adei)
        {
            using var db = new AppDB();
            bool isExecuted = adei.AddDataEntryIssuanceWarehouseman(db, adei);
            return isExecuted? Ok(): BadRequest();
        }
    }
}
