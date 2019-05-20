using UnsugarCoded.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace UnsugarCoded.Controllers
{
public class HomeController : Controller
{

  [HttpGet("/")]
  public ActionResult Index()
  {
    return View();
  }

}
}
