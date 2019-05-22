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
public ActionResult Create(string foodDinner, string sugarLevelDinner, DateTime stampTimeDinner, string carbDinner, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Dinner newDinner = new Dinner(foodDinner, stampTimeDinner, float.Parse(sugarLevelDinner), float.Parse(carbDinner), loginId);
	newDinner.Save();
	List<Dinner> newList = foundLogin.GetDinners();

	ViewBag.Dinner = newList;
	return View("Index", foundLogin);
}
}
}
