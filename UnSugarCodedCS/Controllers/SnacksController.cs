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
public class SnacksController : Controller
{

[HttpPost("/logins/{loginId}/snack")]
public ActionResult Create(string food, string sugarLevel, DateTime stampTime, string carb, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Snack newSnack = new Snack(food, stampTime, float.Parse(sugarLevel), float.Parse(carb), loginId);
	newSnack.Save();
	List<Snack> newList = foundLogin.GetSnacks();

	ViewBag.Snack = newList;
	return View("Index", foundLogin);
}
}
}
