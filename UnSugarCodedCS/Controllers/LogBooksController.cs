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

[HttpGet("/logbook/new")]
public ActionResult New()
{
	return View("New");
}
}
}
