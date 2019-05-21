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
public class LogBooksController : Controller
{
// [HttpGet("/logins/{id}/logbooks/breakfast")]
// public ActionResult Index(id)
// {
// 	Login login = Login.Find(id);
// 	return View();
// }
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

[HttpGet("/logins/{loginId}/logbooks/new")]
public ActionResult New(int loginId)
{
   Login login = Login.Find(loginId);
   return View(login);
}

[HttpPost("/logins/{loginId}/logbooks/breakfast")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	LogBook newLogBook = new LogBook(food, "", "", "", stampTime, new DateTime(), new DateTime(), new DateTime(), float.Parse(sugarLevel), 0, 0, 0, float.Parse(carb), 0, 0, 0, loginId);
	newLogBook.Save();
	List<LogBook> newList = foundLogin.GetLogBooks();

	ViewBag.Breakfast = newList;
	return View("Index", foundLogin);
}

[HttpPost("/logins/{loginId}/logbooks/lunch")]
public ActionResult CreateLunch(string foodLunch, string sugarLevelLunch, DateTime stampTimeLunch, string carbLunch, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	LogBook newLogBook = new LogBook( "", foodLunch, "", "", new DateTime(), stampTimeLunch,new DateTime(), new DateTime(),  0, float.Parse(sugarLevelLunch),0, 0, 0,float.Parse(carbLunch),0, 0, loginId);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	ViewBag.Lunch = newList;
	return View("IndexLunch", foundLogin);
}

[HttpPost("/logins/{loginId}/logbooks/dinner")]
public ActionResult CreateDinner(string foodDinner, string sugarLevelDinner, DateTime stampTimeDinner, string carbDinner, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	LogBook newLogBook = new LogBook( "", "", foodDinner,"",  new DateTime(), new DateTime(), stampTimeDinner,new DateTime(),  0, 0,float.Parse(sugarLevelDinner), 0,  0, 0,float.Parse(carbDinner), 0, loginId);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	ViewBag.Dinner = newList;
	return View("IndexDinner", foundLogin);
}

[HttpPost("/logins/{loginId}/logbooks/snack")]
public ActionResult CreateSnack(string foodSnack, string sugarLevelSnack, DateTime stampTimeSnack, string carbSnack, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	LogBook newLogBook = new LogBook( "", "", "",foodSnack,  new DateTime(), new DateTime(), new DateTime(), stampTimeSnack, 0, 0, 0, float.Parse(sugarLevelSnack), 0, 0, 0, float.Parse(carbSnack),loginId);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	ViewBag.Snack = newList;
	return View("IndexSnack", foundLogin);
}


[HttpGet("/LogBooks/indexlogbook")]
public ActionResult AllLogBooks()
{

	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}

// [HttpPost("/logins/{id}/logbooks/breakfast/deletebreakfast")]
// public ActionResult DeleteBreakfast(int id)
// {
// 	Login login = Login.Find(id);
//   List<LogBook> loginLogBooks = login.GetLogBooks();
//   foreach(LogBook logbook in loginLogBooks)
//   {
//     logbook.DeleteBreakfast();
//   }
//   return RedirectToAction("Index");
// }
//
// [HttpPost("/logins/{id}/logbooks/lunch/deletelunch")]
// public ActionResult DeleteLunch()
// {
// 	LogBook newLogBook = new LogBook( "", "", "","",  new DateTime(), new DateTime(), new DateTime(),new DateTime(), 0, 0,0, 0, 0, 0,0, 0, 0);
// 	newLogBook.DeleteLunch();
// 	List<LogBook> newList = LogBook.GetAll();
// 	return RedirectToAction("Index");
// }
//
// [HttpPost("/dinner/deletedinner")]
// public ActionResult DeleteDinner()
// {
// 	LogBook newLogBook = new LogBook( "", "", "","",  new DateTime(), new DateTime(), new DateTime(),new DateTime(), 0, 0,0, 0, 0, 0,0, 0, 0);
// 	newLogBook.DeleteDinner();
// 	List<LogBook> newList = LogBook.GetAll();
// 	return RedirectToAction("Index");
// }
//
// [HttpPost("/snack/deletesnack")]
// public ActionResult DeleteSnack()
// {
// 	LogBook newLogBook = new LogBook( "", "", "","",  new DateTime(), new DateTime(), new DateTime(),new DateTime(), 0, 0,0, 0, 0, 0,0, 0, 0);
// 	newLogBook.DeleteSnack();
// 	List<LogBook> newList = LogBook.GetAll();
// 	return RedirectToAction("Index");
// }
}
}
