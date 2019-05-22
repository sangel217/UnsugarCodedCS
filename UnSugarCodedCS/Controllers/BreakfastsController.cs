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
public class BreakfastsController : Controller
{

[HttpPost("/logins/{loginId}/breakfast")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Breakfast newBreakfast = new Breakfast(food, stampTime, float.Parse(sugarLevel), float.Parse(carb), loginId);
	newBreakfast.Save();
  //Console.WriteLine(newBreakfast.GetId());
	List<Breakfast> newList = foundLogin.GetBreakfasts();

	ViewBag.Breakfast = newList;
	return View("Index", foundLogin);
}

// [HttpPost("logins/{loginId}/breakfast/{breakfastId}/deletebreakfast")]
// public ActionResult DeleteBreakfast(int loginId, int breakfastId)
// {
//   Login foundLogin = Login.Find(loginId);
//   Breakfast foundBreakfast = Breakfast.Find(breakfastId);
//   foundBreakfast.Delete();
//   return RedirectToAction("Index");
// }
}
}
