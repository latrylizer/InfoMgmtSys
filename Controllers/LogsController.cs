using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.Logs;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Authorization;

namespace InfoMgmtSys.Controllers
{
    public class LogsController : Controller
    {
        [Authorize]
        [HttpPost("AddLogs")]
        public IActionResult AddLogs([FromBody]AddLogs addLogs)
        {
            return Ok(addLogs);
        }
        [Authorize]
        [HttpGet("GetLogsCurrentMonth")]
        public IActionResult GetLogs()
        {
            try {
                var result = InfoMgmtSys.Models.Logs.GetLogs.ExeGetLogs();
                return ExeResultWithDataGet(result);
            } 
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
            
        }
        [Authorize]
        [HttpGet("GetLogsBySearch")]
        public IActionResult GetLogsBySearch(GetLogs.GetLogsBySearchParams getLogsBySearchParams)
        {
            try
            {
                var result = InfoMgmtSys.Models.Logs.GetLogs.ExeGetLogsBySearch(getLogsBySearchParams);
                return ExeResultWithDataGet(result);
            }
            catch (Exception ex)
            {
                return ExeResultIsNull(ex.Message);
            }
           
        }

        private IActionResult ExeResultWithDataGet(dynamic data)
        {
            var dType = ((object)data).GetType().Name;
            if (dType == "String")
            {
                return BadRequest(RequestResult.ExeResponse("Error", data));
            }
            else
            {
                return Ok(RequestResult.ExeResponse("Success", data));
            }
        }
        private IActionResult ExeResultIsNull(dynamic data)
        {
            return BadRequest(RequestResult.ExeResponse("Error", data));
        }
    }
}
