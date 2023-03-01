using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;
using System;

namespace Tamagotchi.Controllers
{
  public class TamagotchisController : Controller
  {
    [HttpGet("/tamagotchis")]
    public ActionResult Index()
    {
      List<Pet> allTamagotchis = Pet.GetAll();
      return View(allTamagotchis);
    }

    [HttpGet("/tamagotchis/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/tamagotchis")]
    public ActionResult Create(string name)
    {
      Pet myTamagotchi = new Pet(name);
      return RedirectToAction("Index");
    }
  }
}