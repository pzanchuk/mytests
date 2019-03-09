using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allstylists = Stylist.GetAll();
      return View(allstylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      List<Stylist> allstylists = Stylist.GetAll();
      return View("Index", allstylists);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      List<Specialty> allSpecialties = Specialty.GetAll();
      List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistClients);
      model.Add("allSpecialties", allSpecialties);
      model.Add("stylistSpecialties", stylistSpecialties);
      return View(model);
    }

    // This one creates new Clients within a given Stylist, not new stylists:
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string clientName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      List<Client> stylistClients = foundStylist.GetClients();
      List<Specialty> allSpecialties = Specialty.GetAll();
      List<Specialty> stylistSpecialties = foundStylist.GetSpecialties();
      model.Add("clients", stylistClients);
      model.Add("stylist", foundStylist);
      model.Add("allSpecialties", allSpecialties);
      model.Add("stylistSpecialties", stylistSpecialties);

      return View("Show", model);
    }

    [HttpPost("/stylists/{stylistId}/specialties/new")]
    public ActionResult AddCategory(int stylistId, int specialtyId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Specialty specialty = Specialty.Find(specialtyId);
      stylist.AddSpecialty(specialty);
      return RedirectToAction("Show",  new { id = stylistId });
    }

    [HttpPost("/stylists/{stylistId}/clients/deleteall")]
    public ActionResult DeleteAllClients(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.DeleteClients();
      return RedirectToAction("Show",  new { id = stylistId });
    }

    [HttpPost("/stylists/{stylistId}/delete")]
    public ActionResult Delete(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/deleteall")]
    public ActionResult DeleteAll()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }

    //Update Stylist
    [HttpPost("/stylists/{stylistId}/update")]
    public ActionResult Update(int stylistId, string newName)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.Edit(newName);
      return RedirectToAction("Show",  new { id = stylistId });
    }

    //Edits Stylist
    [HttpGet("/stylists/{stylistId}/edit")]
    public ActionResult Edit(int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      return View(model);
    }

  }
}
