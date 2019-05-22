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
public class LunchsController : Controller
{

[HttpPost("/logins/{loginId}/lunch")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Lunch newLunch = new Lunch(food, stampTime, float.Parse(sugarLevel), float.Parse(carb), loginId);
	newLunch.Save();
	List<Lunch> newList = foundLogin.GetLunchs();

	ViewBag.Lunch = newList;
	return View("Index", foundLogin);
}
}
}
