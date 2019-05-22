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

[HttpGet("/logins/{id}/breakfast")]
public ActionResult Index(int id)
{
  Login login = Login.Find(id);
  List<Breakfast> allBreakfasts = login.GetBreakfasts();
  ViewBag.Breakfast = allBreakfasts;
  return View("Index", login);
}

[HttpPost("/logins/{loginId}/breakfast")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Breakfast newBreakfast = new Breakfast(food, stampTime, float.Parse(sugarLevel), float.Parse(carb), loginId);
	newBreakfast.Save();
  //int breakfastId = newBreakfast.GetId();
	List<Breakfast> newList = foundLogin.GetBreakfasts();
  //newList.ForEach( i => Console.Write("{0}\t", i));
  //Console.WriteLine(foreach (var view in newlist){return view});
	ViewBag.Breakfast = newList;
  //ViewBag.BreakfastId = breakfastId;
	return View("Index", foundLogin);
}

// [HttpGet("/logins/{id}/breakfast/deleted")]
// public ActionResult Delete(int id)
// {
//   return View();
// }

// [HttpPost("/logins/{loginId}/breakfast/delete")]
// public ActionResult DeleteBreakfast(int loginId)
// {
//   Login login = Login.Find(loginId);
//   List<Breakfast> loginBreakfasts = login.GetBreakfasts();
//   foreach(Breakfast logbook in loginBreakfasts)
//   {
//     logbook.Delete();
//   }
//   return RedirectToAction("Index");
// }
}
}
