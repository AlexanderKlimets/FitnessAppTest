using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var rnd = new Random();
            var userName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var foodName = Guid.NewGuid().ToString();
            var food = new Food(foodName, rnd.Next(50, 550),
                                          rnd.Next(50, 550),
                                          rnd.Next(50, 550),                                        
                                          rnd.Next(50, 550));
            
            // Act
            eatingController.Eating.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}