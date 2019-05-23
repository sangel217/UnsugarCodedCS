using UnSugarCodedCS.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

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
[HttpGet("/logins/{loginId}/lunchChart")]
public ActionResult AllLogBooksForUser(int loginId)
{
  Login foundLogin = Login.Find(loginId);
	List<Lunch> newList = foundLogin.GetLunchs();
  StringBuilder sb = new StringBuilder("date,value\n");
	foreach (Lunch lunch in newList)
	{
			sb.Append(lunch.GetLunchStampTime().ToString("MM/dd/yyyy")+","+lunch.GetLunchSugar()+"\n");
	}
	return Content(sb.ToString(),"text/csv");
}
}
}
