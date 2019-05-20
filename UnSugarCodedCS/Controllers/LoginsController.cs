// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using UnSugarCodedCS.Models;
//
// namespace UnSugarCodedCS.Controllers
// {
//   public class LoginsController : Controller
//   {
//     [HttpGet("/logins")]
//     public ActionResult Index()
//     {
//       List<Login> allLogins = Login.GetAll();
//       return View(allLogins);
//     }
//
//     [HttpGet("/logins/new")]
//     public ActionResult New()
//     {
//       return View();
//     }
//
//     [HttpPost("/logins")]
//     public ActionResult Create(string loginName, loginEmail, loginHeight, loginWeight)
//     {
//       Login newLogin = new Login(loginName, loginEmail, loginHeight, LoginWeight);
//       newLogin.Save();
//       List<Login> allLogins = Login.GetAll();
//       return View("Index", allLogins);
//     }
//   }
// }
