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

[HttpPost("/sugar/{userInput}")]
public JsonResult GetSugarNames ( string userInput)
{
	List<string> allSugars = FoodSugar.GetAllFoodNames(userInput);

	return Json(allSugars);
}

[HttpPost("/sugarLevel/{name}")]
public JsonResult GetSugarLevels (string name)
{
	Console.WriteLine("Name " + name);
	float allSugarLevels = FoodSugar.GetAllSugarLevel(name);
	Console.WriteLine("allSugarLevels " + allSugarLevels);

	return Json(allSugarLevels.ToString());
}

[HttpPost("/breakfast")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb)
{
	LogBook newLogBook = new LogBook(food, "", "", "", stampTime, new DateTime(), new DateTime(), new DateTime(), float.Parse(sugarLevel), 0, 0, 0, float.Parse(carb), 0, 0, 0, 5);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}

[HttpPost("/lunch")]
public ActionResult CreateLunch(string foodLunch, string sugarLevelLunch, DateTime stampTimeLunch, string carbLunch)
{
	LogBook newLogBook = new LogBook( "", foodLunch, "", "", new DateTime(), stampTimeLunch,new DateTime(), new DateTime(),  0, float.Parse(sugarLevelLunch),0, 0, 0,float.Parse(carbLunch),0, 0, 5);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}

[HttpPost("/dinner")]
public ActionResult CreateDinner(string foodDinner, string sugarLevelDinner, DateTime stampTimeDinner, string carbDinner)
{
	LogBook newLogBook = new LogBook( "", "", foodDinner,"",  new DateTime(), new DateTime(), stampTimeDinner,new DateTime(),  0, 0,float.Parse(sugarLevelDinner), 0,  0, 0,float.Parse(carbDinner), 0, 5);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}

[HttpPost("/snack")]
public ActionResult CreateSnack(string foodSnack, string sugarLevelSnack, DateTime stampTimeSnack, string carbSnack)
{
	LogBook newLogBook = new LogBook( "", "", "",foodSnack,  new DateTime(), new DateTime(), new DateTime(), stampTimeSnack, 0, 0, 0, float.Parse(sugarLevelSnack), 0, 0, 0, float.Parse(carbSnack),5);
	newLogBook.Save();
	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}


[HttpGet("/LogBooks/indexlogbook")]
public ActionResult AllLogBooks()
{

	List<LogBook> newList = LogBook.GetAll();
	return View("Index",newList);
}

[HttpGet("/logbook/new")]
public ActionResult New()
{
	return View("New");
}
}
}
