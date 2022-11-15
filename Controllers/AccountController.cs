using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.Accounts;
using InfoMgmtSys.Security;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace InfoMgmtSys.Controllers
{
    public class AccountController : Controller
    {
        public class UserRefreshToken
        {
            public string? Username { get; set; }
            public string? UserPosition { get; set; }
            public string? RefreshToken { get; set; }
            public DateTime TokenCreated { get; set; }
            public DateTime TokenExpires { get; set; }
        }
        public static UserRefreshToken userToken= new UserRefreshToken();
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
        public IActionResult ExeLoginWithToken([FromBody] LoginWithToken.LoginParams loginParams)

        {
            try
            {
                var header = this.HttpContext.Request.Headers.ToList();
                using var db = new AppDB();
                dynamic result = LoginWithToken.ExeGetToken(db, loginParams);
                dynamic refreshToken = Tokens.GetRefreshToken();
                userToken.Username = result.Name;
                userToken.UserPosition = result.Position;
                SetRefreshToken(refreshToken);

                Console.WriteLine(userToken.Username + " " + userToken.UserPosition);

                return ExeResultWithData(result);
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("RefreshToken")]
        public IActionResult ExeRefreshtoken()

        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];

                if (userToken.RefreshToken != refreshToken)
                {
                    return Unauthorized("Invalid Refresh Token");
                }
                if (userToken.TokenExpires < DateTime.Now)
                {
                    return Unauthorized("Token Expired");
                }

                string token = Tokens.CreateToken(userToken.Username!, userToken.UserPosition!);

                return Ok(RequestResult.ExeResponse("Success", token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       
        private void SetRefreshToken(dynamic data)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = data.Expires,
            };
            Response.Cookies.Append("refreshToken", data.Token, cookieOptions);

            userToken.RefreshToken = data.Token;
            userToken.TokenCreated = DateTime.Now;
            userToken.TokenExpires = data.Expires;
        }
        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
        private IActionResult ExeResultWithData(dynamic data)
        {
            var type = data.GetType().Name;
            if(type == "String")
            {
                if (data == "Account don't exist")

                    {
                        return Ok(RequestResult.ExeResponse("Success", data));
                    }
                    else
                    {
                        return BadRequest(RequestResult.ExeResponse("Error", data));
                    }
            }
            else
            {
             return Ok(RequestResult.ExeResponse("Success", data));
            }
        }
    }
}
