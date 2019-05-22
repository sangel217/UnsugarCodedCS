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

[HttpPost("/sugar/{userInput}")]
public JsonResult GetSugarNames ( string userInput)
{
	List<string> allSugars = FoodSugar.GetAllFoodNames(userInput);

	return Json(allSugars);
}

[HttpPost("/sugarLevel/{name}")]
public JsonResult GetSugarLevels (string name)
{

	float allSugarLevels = FoodSugar.GetAllSugarLevel(name);
	return Json(allSugarLevels.ToString());
}

[HttpGet("/logins/{loginId}/new")]
public ActionResult New(int loginId)
{
	Login login = Login.Find(loginId);
	return View(login);
}

}
}
