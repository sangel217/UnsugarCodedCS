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
public ActionResult Create(string foodLunch, string sugarLevelLunch, DateTime stampTimeLunch, string carbLunch, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Lunch newLunch = new Lunch(foodLunch, stampTimeLunch, float.Parse(sugarLevelLunch), float.Parse(carbLunch), loginId);
	newLunch.Save();
	List<Lunch> newList = foundLogin.GetLunchs();

	ViewBag.Lunch = newList;
	return View("Index", foundLogin);
}
}
}
