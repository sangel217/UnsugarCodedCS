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

	[HttpGet("/logins/{id}/lunch")]
	public ActionResult Index(int id)
	{
	  Login login = Login.Find(id);
	  List<Lunch> allLunchs = Lunch.GetAllLunch();
	  ViewBag.Lunch = allLunchs;
	  return View("Index", login);
	}

[HttpPost("/logins/{loginId}/lunch")]
public ActionResult Create(string foodLunch, string sugarLevelLunch, DateTime stampTimeLunch, string carbLunch, int loginId)
{
	Login foundLogin = Login.Find(loginId);
	Lunch newLunch = new Lunch(foodLunch, stampTimeLunch, float.Parse(sugarLevelLunch), float.Parse(carbLunch), loginId);
	newLunch.Save();
	List<Lunch> newList = Lunch.GetAllLunch();

	ViewBag.Lunch = newList;
	return View("Index", foundLogin);
}
[HttpPost("/logins/{id}/lunch/{lunchId}/delete")]
public ActionResult DeleteLunch(int id, int lunchId)
{
	Lunch lunch =Lunch.Find(lunchId);
	lunch.Delete();
	Login login = Login.Find(id);
	List<Lunch> allLunchs = Lunch.GetAllLunch();
	ViewBag.Lunch = allLunchs;
	return View("Index", login);
}


}
}
