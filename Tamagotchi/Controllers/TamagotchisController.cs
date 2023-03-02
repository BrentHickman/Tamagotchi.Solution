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

    [HttpPost("/tamagotchis/feed")]
    public ActionResult Feed(int passInId)
    {
      string petName = Pet.Find(passInId).Name;
      Pet.Eat(passInId);
      Pet.DeathCheck();
      return View();
    }

    [HttpPost("/tamagotchis/play")]
    public ActionResult Play(int passInId)
    {
      string petName = Pet.Find(passInId).Name;
      Pet.Play(passInId);
      Pet.DeathCheck();
      return View();
    }

    [HttpPost("/tamagotchis/rest")]
    public ActionResult Rest(int passInId)
    {
      string petName = Pet.Find(passInId).Name;
      Pet.Rest(passInId);
      Pet.DeathCheck();
      return View();
    }


    [HttpPost("/tamagotchis/endofday")]
    public ActionResult EndOfDay()
    {
      Pet.EndDay();
      Pet.DeathCheck();
      return View();
    }
    
    [HttpPost("/tamagotchis/delete")]
    public ActionResult DeleteAll()
    {
      Pet.ClearAll();
      return View();
    }
  }
}