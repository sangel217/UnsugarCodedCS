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

	[HttpGet("/logins/{id}/dinner")]
	public ActionResult Index(int id)
	{
	  Login login = Login.Find(id);
	  List<Dinner> allDinners = Dinner.GetAllDinner();
	  ViewBag.Dinner = allDinners;
	  return View("Index", login);
	}

[HttpPost("/logins/{loginId}/dinner")]
public ActionResult Create(string foodDinner, string sugarLevelDinner, DateTime stampTimeDinner, string carbDinner, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Dinner newDinner = new Dinner(foodDinner, stampTimeDinner, float.Parse(sugarLevelDinner), float.Parse(carbDinner), loginId);
	newDinner.Save();
	List<Dinner> newList = Dinner.GetAllDinner();

	ViewBag.Dinner = newList;
	return View("Index", foundLogin);
}
[HttpPost("/logins/{id}/dinner/{dinnerId}/delete")]
public ActionResult DeleteDinner(int id, int dinnerId)
{
  Dinner dinner = Dinner.Find(dinnerId);
  dinner.Delete();
  Login login = Login.Find(id);
  List<Dinner> allDinners = Dinner.GetAllDinner();
  ViewBag.Dinner = allDinners;
  return View("Index", login);
}
}
}
