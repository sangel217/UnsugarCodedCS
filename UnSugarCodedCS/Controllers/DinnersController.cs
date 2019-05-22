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
public class DinnersController : Controller
{

[HttpPost("/logins/{loginId}/dinner")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Dinner newDinner = new Dinner(food, stampTime, float.Parse(sugarLevel), float.Parse(carb), loginId);
	newDinner.Save();
	List<Dinner> newList = foundLogin.GetDinners();

	ViewBag.Dinner = newList;
	return View("Index", foundLogin);
}
}
}
