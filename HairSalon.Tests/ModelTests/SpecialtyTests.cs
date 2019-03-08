using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Specialty.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=pavel_zanchuk_test;";
    }

    [TestMethod]
    public void GetSpecialty_ReturnSpecialty_String()
    {
      string name = "Specialty";
      Specialty newSpecialty = new Specialty(name, 1);
      string result = newSpecialty.GetSpecialty();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      List<Specialty> newList = new List<Specialty> {};
      List<Specialty> result = Specialty.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllSpecialty_SpecialtyList()
    {
      string name01 = "Name";
      string name02 = "Name2";
      Specialty newSpecialty1 = new Specialty(name01, 1);
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty(name02, 1);
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };
      List<Specialty> result = Specialty.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
    {
      Specialty testSpecialty = new Specialty("Name", 1);
      testSpecialty.Save();
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
    {
      Client firstSpecialty = new Client("Special", 1);
      Client secondSpecialty = new Client("Special", 1);
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      Specialty testSpecialty = new Specialty("Specialty", 1);
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Specialty testSpecialty = new Specialty("Specialty", 1);
      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];
      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();
      Assert.AreEqual(testId, result);
    }
  }
}
