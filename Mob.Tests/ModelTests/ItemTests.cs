// using MySql.Data.MySqlClient;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using Mob.Models;
// using System;

// namespace Mob.Tests
// {

//   [TestClass]
//   public class JobTests : IDisposable
//   {

//     public void Dispose()
//     {
//       Job.ClearAll();
//     }
//     public void JobTest()
//     {
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
//     }

//     [TestMethod]
//     public void JobConstructor_CreatesInstanceOfJob_Job()
//     {
//       Job newJob = new Job("test");
//       Assert.AreEqual(typeof(Job), newJob.GetType());
//     }

//     [TestMethod]
//     public void GetDescription_ReturnsDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";

//       //Act
//       Job newJob = new Job(description);
//       string result = newJob.Description;

//       //Assert
//       Assert.AreEqual(description, result);
//     }

//     [TestMethod]
//     public void SetDescription_SetDescription_String()
//     {
//       //Arrange
//       string description = "Walk the dog.";
//       Job newJob = new Job(description);

//       //Act
//       string updatedDescription = "Do the dishes";
//       newJob.Description = updatedDescription;
//       string result = newJob.Description;

//       //Assert
//       Assert.AreEqual(updatedDescription, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsEmptyList_JobList()
//     {
//       // Arrange
//       List<Job> newList = new List<Job> { };

//       // Act
//       List<Job> result = Job.GetAll();

//       // Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsJobs_JobList()
//     {
//       //Arrange
//       string description01 = "Walk the dog";
//       string description02 = "Wash the dishes";
//       Job newJob1 = new Job(description01);
//       newJob1.Save();
//       Job newJob2 = new Job(description02);
//       newJob2.Save();
//       List<Job> newList = new List<Job> { newJob1, newJob2 };

//       //Act
//       List<Job> result = Job.GetAll();

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Job()
//     {
//       // Arrange, Act
//       Job firstJob = new Job("Mow the lawn");
//       Job secondJob = new Job("Mow the lawn");

//       // Assert
//       Assert.AreEqual(firstJob, secondJob);
//     }

//     [TestMethod]
//     public void Save_SavesToDatabase_JobList()
//     {
//       //Arrange
//       Job testJob = new Job("Mow the lawn");

//       //Act
//       testJob.Save();
//       List<Job> result = Job.GetAll();
//       List<Job> testList = new List<Job>{testJob};

//       //Assert
//       CollectionAssert.AreEqual(testList, result);
//     }

//     [TestMethod]
//     public void Find_ReturnsCorrectJobFromDatabase_Job()
//     {
//       //Arrange
//       Job newJob = new Job("Mow the lawn");
//       newJob.Save();
//       Job newJob2 = new Job("Wash dishes");
//       newJob2.Save();

//       //Act
//       Job foundJob = Job.Find(newJob.Id);
//       //Assert
//       Assert.AreEqual(newJob, foundJob);
//     }
//   }
// }