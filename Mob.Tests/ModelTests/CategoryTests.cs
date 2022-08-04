// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Mob.Models;
// using System.Collections.Generic;
// using System;

// namespace Mob.Tests
// {
//   [TestClass]
//   public class CriminalTests : IDisposable
//   {

//     public void Dispose()
//     {
//       Criminal.ClearAll();
//     }

//     [TestMethod]
//     public void CriminalConstructor_CreatesInstanceOfCriminal_Criminal()
//     {
//       Criminal newCriminal = new Criminal("test criminal");
//       Assert.AreEqual(typeof(Criminal), newCriminal.GetType());
//     }

//     [TestMethod]
//     public void GetName_ReturnsName_String()
//     {
//       //Arrange
//       string name = "Test Criminal";
//       Criminal newCriminal = new Criminal(name);

//       //Act
//       string result = newCriminal.Name;

//       //Assert
//       Assert.AreEqual(name, result);
//     }

//     [TestMethod]
//     public void GetId_ReturnsCriminalId_Int()
//     {
//       //Arrange
//       string name = "Test Criminal";
//       Criminal newCriminal = new Criminal(name);

//       //Act
//       int result = newCriminal.Id;

//       //Assert
//       Assert.AreEqual(1, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsAllCriminalObjects_CriminalList()
//     {
//       //Arrange
//       string name01 = "Work";
//       string name02 = "School";
//       Criminal newCriminal1 = new Criminal(name01);
//       Criminal newCriminal2 = new Criminal(name02);
//       List<Criminal> newList = new List<Criminal> { newCriminal1, newCriminal2 };

//       //Act
//       List<Criminal> result = Criminal.GetAll();

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void Find_ReturnsCorrectCriminal_Criminal()
//     {
//       //Arrange
//       string name01 = "Work";
//       string name02 = "School";
//       Criminal newCriminal1 = new Criminal(name01);
//       Criminal newCriminal2 = new Criminal(name02);

//       //Act
//       Criminal result = Criminal.Find(2);

//       //Assert
//       Assert.AreEqual(newCriminal2, result);
//     }

//     [TestMethod]
//     public void AddJob_AssociatesJobWithCriminal_JobList()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Job newJob = new Job(description);
//       List<Job> newList = new List<Job> { newJob };
//       string name = "Work";
//       Criminal newCriminal = new Criminal(name);
//       newCriminal.AddJob(newJob);

//       //Act
//       List<Job> result = newCriminal.Jobs;

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }
    
//   }
// }