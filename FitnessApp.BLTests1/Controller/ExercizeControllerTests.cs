using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class ExercizeControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var exerciseController = new ExercizeController(userController.CurrentUser);
            var activityName = Guid.NewGuid().ToString();
            var activity = new Activity(activityName, rnd.Next(50, 550));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now);

            // Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}