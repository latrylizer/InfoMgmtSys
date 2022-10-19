using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.Accounts;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Authorization;

namespace InfoMgmtSys.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddPosition")]
        public IActionResult AddPosition([FromForm] AddPosition addPosition)
        {
            using var db = new AppDB();
            bool isExecuted = addPosition.ExeAddPosition(db, addPosition);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromForm] AddEmployee addEmployee)
        {
            using var db = new AppDB();
            bool isExecuted = addEmployee.ExeAddEmployee(db, addEmployee);
            return ExeResult(isExecuted);
        }
        [HttpPost("AddAccountAccess")]
        public IActionResult AddAccountAccess([FromForm] AddAccountAccess addAccountAccess)
        {
            using var db = new AppDB();
            bool isExecuted = addAccountAccess.ExeAddAccountAccess(db, addAccountAccess);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdatePosition")]
        public IActionResult UpdatePosition([FromForm] UpdatePosition updatePosition)
        {
            using var db = new AppDB();
            bool isExecuted = updatePosition.ExeUpdatePosition(db, updatePosition);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromForm] UpdateEmployee updateEmployee)
        {
            using var db = new AppDB();
            bool isExecuted = updateEmployee.ExeUpdateEmployee(db, updateEmployee);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateAccountAccessByEmployeeId")]
        public IActionResult UpdateAccountAccessByEmployeeId([FromForm] UpdateAccountAccessByEmployeeId updateAccountAccessByEmployeeId)
        {
            using var db = new AppDB();
            bool isExecuted = updateAccountAccessByEmployeeId.ExeUpdateAccountAccessByEmployeeId(db, updateAccountAccessByEmployeeId);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdateUsername")]
        public IActionResult UpdateUsername([FromForm] UpdateUsername updateUsername)
        {
            using var db = new AppDB();
            bool isExecuted = updateUsername.ExeUpdateUsername(db, updateUsername);
            return ExeResult(isExecuted);
        }
        [HttpPut("UpdatePassword")]
        public IActionResult UpdatePassword([FromForm] UpdatePassword updatePassword)
        {
            using var db = new AppDB();
            bool isExecuted = updatePassword.ExeUpdatePassword(db, updatePassword);
            return ExeResult(isExecuted);
        }
        [HttpGet("GetPostion")]
        public ActionResult<List<GetPostion>> ExeGetLatestRrNo()
        {
            using var db = new AppDB();
            var list = GetPostion.ExeGetPosition(db);
            return list;
        }
        [HttpGet("GetEmployeeById")]
        public ActionResult<List<GetEmployeeById>> ExeGetLatestRrNo([FromQuery] GetEmployeeById.GetEmployeeByIdParams getEmployeeByIdParams)
        {
            using var db = new AppDB();
            var list = GetEmployeeById.ExeGetEmployeeById(db, getEmployeeByIdParams);
            return list;
        }
        [HttpGet("GetAccountAccessByEmployeeId")]
        public ActionResult<List<GetAccountAccessByEmployeeId>> ExeGetAccountAccessByEmployeeId([FromQuery] GetAccountAccessByEmployeeId.GetAccountAccessByEmployeeIdParams getAccountAccessByEmployeeIdParams)
        {
            using var db = new AppDB();
            var list = GetAccountAccessByEmployeeId.ExeGetAccountAccessByEmployeeId(db, getAccountAccessByEmployeeIdParams);
            return list;
        }
        [Authorize]
        [HttpPost("Login")]
        public ActionResult<RequestResult> ExeGetAccountAccessByEmployeeId([FromForm] Login.LoginParams loginParams)
        {
            using var db = new AppDB();
            var header = this.HttpContext.Request.Headers.ToList()[6];
            var list = Login.ExeLogin(db, loginParams);

            var res = RequestResult.ExeResponse("Success",list);
            return res;
        }
        [HttpPost("LoginWithToken")]
        public ActionResult<string> ExeLoginWithToken([FromForm] LoginWithToken.LoginParams loginParams)

        {
            using var db = new AppDB();
            string token = LoginWithToken.ExeGetToken(db, loginParams);
            return token;
        }
        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
    }
}
