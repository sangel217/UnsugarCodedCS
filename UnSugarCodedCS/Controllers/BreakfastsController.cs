using UnSugarCodedCS.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Text;
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
  List<Breakfast> allBreakfasts = Breakfast.GetAllBreakfast();
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
	List<Breakfast> newList = Breakfast.GetAllBreakfast();
  //newList.ForEach( i => Console.Write("{0}\t", i));
  //Console.WriteLine(foreach (var view in newlist){return view});
	ViewBag.Breakfast = newList;
  //ViewBag.BreakfastId = breakfastId;
	return View("Index", foundLogin);
}

[HttpPost("/logins/{id}/breakfast/{breakfastId}/delete")]
public ActionResult DeleteBreakfast(int id, int breakfastId)
{
  Breakfast breakfast = Breakfast.Find(breakfastId);
  breakfast.Delete();
  Login login = Login.Find(id);
  List<Breakfast> allBreakfasts = Breakfast.GetAllBreakfast();
  ViewBag.Breakfast = allBreakfasts;
  return View("Index", login);
  
[HttpGet("/logins/{loginId}/breakfastChart")]
public ActionResult AllLogBooksForUser(int loginId)
{
  Login foundLogin = Login.Find(loginId);
	List<Breakfast> newList = foundLogin.GetBreakfasts();
  StringBuilder sb = new StringBuilder("date,value\n");
	foreach (Breakfast breakfast in newList)
	{
			sb.Append(breakfast.GetBreakfastStampTime().ToString("MM/dd/yyyy")+","+breakfast.GetBreakfastSugar()+"\n");
	}
	return Content(sb.ToString(),"text/csv");
}
}
}
