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
    float allSugarLevels = FoodSugar.GetAllSugarLevel(name);

    return Json(allSugarLevels.ToString());
  }

  [HttpPost("/details")]
   public ActionResult Create(string breakfast, string lunch, string dinner, string snack, DateTime stampTimeBreakfast, DateTime stampTimeLunch, DateTime stampTimeDinner, DateTime stampTimeSnack, float breakfastCarb, float lunchCarb, flo)
   {
     LogBook newLogBook = new LogBook(txtFood,stampTime,sugarLevel,5);
     newLogBook.Save();
     List<LogBook> newList = LogBook.GetAll();
     return View("Show",newList);
   }
}
}
