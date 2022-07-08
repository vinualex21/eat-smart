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
            _controller = new MealController(_mockMealService.Object,_mockUserService.Object);
        }

        [Test]
        public void GetMeals_Returns_Meals()
        {
            //Arrange
            var meals = new List<MealDto>();
            Intolerance t1 = new() { name = "Dairy" };
            Intolerance t2 = new() { name = "Egg" };
            List<Intolerance> IntoleranceList = new List<Intolerance> { t1,t2};
            User newUser = new() { UserId = 4, FirstName = "Apshan" , Surname = "Sithik", MaxDailyCalories  = 1000,
                Intolerances = IntoleranceList};

            string IntolerancesString = string.Join(",", newUser.Intolerances);

            MealRequest newMealRequest = new() { MaxCalories = newUser.MaxDailyCalories,
                Intolerances = IntolerancesString };

            _mockUserService.Setup(u => u.GetUserById(newUser.UserId)).Returns(newUser);
            _mockMealService.Setup(m => m.Get3Meals(newMealRequest)).Returns(meals);

            //Act
            var result = _controller.GetMeals(newUser.UserId);

            //Assert

            result.Should().BeOfType(typeof(ActionResult<List<MealDto>>));


        }

    }
}

