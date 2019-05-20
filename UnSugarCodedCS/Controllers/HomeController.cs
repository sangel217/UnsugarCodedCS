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

  // [HttpPost("/Home/AutoComplete/{userInput}")]
  // public JsonResult GetSugarNames ( string userInput)
  // {
  //   List<string> allSugars = string.GetAllFoodNames(userInput);
  //
  //   return Json(allSugars);
  // }

}
}
