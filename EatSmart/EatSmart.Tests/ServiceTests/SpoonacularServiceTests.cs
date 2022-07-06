using EatSmart.Models;
using EatSmart.Services;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EatSmart.Tests.ServiceTests
{
    public class SpoonacularServiceTests
    {
        private ISpoonacularService spoonacularService; 

        [SetUp]
        public void Setup()
        {
            spoonacularService = new SpoonacularService();
        }

        [Test]
        public void GetRecipes_WithNullCalories_ShouldThrowArgumentNullException()
        {
            spoonacularService.Invoking(y => y.GetRecipes(null))
                                .Should().Throw<ArgumentNullException>()
                                .Where(x => x.Message.Contains("No calories specified"));
        }

        [Test]
        public void GetRecipes_WithNullCalories_ShouldThrowArgumentExceptionException()
        {
            var request = new MealRequest();
            request.MaxCalories = 0;
            spoonacularService.Invoking(y => y.GetRecipes(request))
                                .Should().Throw<ArgumentException>()
                                .WithMessage("Invalid calorie input. Please enter a valid maximum calorie limit.");
        }

        [Test]
        public void GetRecipes_WithMaxCalories_ShouldReturnRecipesBelowGivenCalories()
        {
            //Arrange
            var calories = 400;
            var request = new MealRequest();
            request.MaxCalories = calories;

            //Act
            var result = spoonacularService.GetRecipes(request);

            //Assert
            result.Should().BeOfType(typeof(MealResponse));
            Assert.That(result.Meals.Select(r=>r.Nutrition).SelectMany(r=>r.Nutrients).Where(r=>r.Name=="Calories").All(n => n.Amount < calories));
        }


        

        
    }
}
