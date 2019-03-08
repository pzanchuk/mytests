using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyControllerTest : IDisposable
  {
    public SpecialtyControllerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=pavel_zanchuk_test;";
    }

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }

    [TestMethod]
    public void Index_ReturnsCorrectType_ActionResult()
    {
      SpecialtyController controller = new SpecialtyController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void New_ReturnsCorrectType_True()
    {
      SpecialtyController controller = new SpecialtyController();
      IActionResult view = controller.New();
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateStylist_ReturnsCorrectType_ActionResult()
    {
      SpecialtyController controller = new SpecialtyController();
      IActionResult view = controller.Create("Name");
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateSpecialty_ReturnsCorrectType_ActionResult()
    {
      SpecialtyController controller = new SpecialtyController();
      IActionResult view = controller.Create("Name");
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_ReturnsCorrectType_ActionResult()
    {
      SpecialtyController controller = new SpecialtyController();
      IActionResult view = controller.Show(1);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_HasCorrectModelType_Dictionary()
    {
      ViewResult view = new SpecialtyController().Show(1) as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void CreateSpecialty_HasCorrectModelType_List()
    {
      ViewResult view = new SpecialtyController().Create("Name") as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }
  }
}
