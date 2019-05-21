using UnSugarCodedCS.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace UnSugarCodedCS.Controllers
{
public class HomeController : Controller
{

[HttpGet("/")]
public ActionResult Index()
{
	return View();
}
[HttpPost("/showForm")]
public ActionResult Show(string userName, string userEmail)
{
	Login newLogin = new Login (userName,userEmail,0,0);
	newLogin.Save();
	return View();
}
}
}
