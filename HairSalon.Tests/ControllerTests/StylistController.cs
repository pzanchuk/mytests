using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest : IDisposable
  {
    public StylistControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=pavel_zanchuk_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }

    [TestMethod]
    public void Index_ReturnsCorrectType_ActionResult()
    {
      StylistController controller = new StylistController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_ReturnsCorrectType_True()
    {
      StylistController controller = new StylistController();
      IActionResult view = controller.New();
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateStylist_ReturnsCorrectType_ActionResult()
    {
      StylistController controller = new StylistController();
      IActionResult view = controller.Create("Name");
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateClient_ReturnsCorrectType_ActionResult()
    {
      StylistController controller = new StylistController();
      IActionResult view = controller.Create(1, "Name");
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectType_ActionResult()
    {
      StylistController controller = new StylistController();
      IActionResult view = controller.Show(1);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateClient_HasCorrectModelType_Dictionary()
    {
      ViewResult view = new StylistController().Create(1, "Name") as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary()
    {
      ViewResult view = new StylistController().Show(1) as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void CreateStylist_HasCorrectModelType_Dictionary()
    {
      ViewResult view = new StylistController().Create("Name") as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }
  }
}
