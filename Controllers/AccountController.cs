﻿using Microsoft.AspNetCore.Mvc;
using InfoMgmtSys.Models.Accounts;

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
        [HttpGet("Login")]
        public ActionResult<List<Login>> ExeGetAccountAccessByEmployeeId([FromQuery] Login.LoginParams loginParams)
        {
            using var db = new AppDB();
            var list = Login.ExeLogin(db, loginParams);
            return list;
        }
        private IActionResult ExeResult(bool result)
        {
            return result ? Ok() : BadRequest();
        }
    }
}