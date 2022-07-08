using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using EatSmart.Controllers;
using EatSmart.Models;
using EatSmart.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
namespace EatSmart.Tests.ControllerTests
{
    public class MealAPITests
    {
        private MealController _controller;
        private Mock<IMealService> _mockMealService;
        private Mock<IUserService> _mockUserService;

        [SetUp]
        public void Setup()
        {
            _mockMealService = new Mock<IMealService>();
            _mockUserService = new Mock<IUserService>();
            _controller = new MealController(_mockMealService.Object, _mockUserService.Object);
        }

        [Test]
        public void GetMeals_Returns_Meals()
        {
            //Arrange
            var meals = new List<MealDto>();
            User newUser = new(4)
            {
                FirstName = "Apshan",
                Surname = "Sithik",
                MaxDailyCalories = 1000,
                Intolerances = "Dairy,Egg"
            };

            
            MealRequest newMealRequest = new()
            {
                MaxCalories = newUser.MaxDailyCalories,
                Intolerances = newUser.Intolerances
            };

            _mockUserService.Setup(u => u.GetUserById(newUser.UserId)).Returns(newUser);
            _mockMealService.Setup(m => m.Get3Meals(newMealRequest)).Returns(meals);

            //Act
            var result = _controller.GetMeals(newUser.UserId);

            //Assert

            result.Should().BeOfType(typeof(ActionResult<List<MealDto>>));


        }

    }
}
