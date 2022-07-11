using EatSmart.Models;
using EatSmart.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EatSmart.Tests.ServiceTests
{
    public class MealServiceTests
    {
        private Mock<ISpoonacularService> spoonacularService;
        private MealService mealService;

        [SetUp]
        public void Setup()
        {
            spoonacularService= new Mock<ISpoonacularService>();
            mealService = new MealService(spoonacularService.Object);
        }

        [Test]
        public void Get3Meals_WithMaxCalories_ReturnsThreeMealsUnderMaxCalories()
        {
            //Arrange
            var request = new MealRequest();
            request.MaxCalories = 3000;

            var breakfastRecipes = GetMealResponse(new List<MealType> { MealType.Breakfast});
            var lunchRecipes = GetMealResponse(new List<MealType> { MealType.Lunch });
            var dinnerRecipes = GetMealResponse(new List<MealType> { MealType.Dinner });

            spoonacularService.SetupSequence(b => b.GetRecipes(It.IsAny<MealRequest>()))
                .Returns(breakfastRecipes)
                .Returns(lunchRecipes)
                .Returns(dinnerRecipes);

            //Act
            var result = mealService.Get3Meals(request);

            //Assert
            result.Should().BeOfType(typeof(List<MealDto>));
            double totalCalories = 0;
            foreach(var item in result)
            {
                var mealCalories = Regex.Replace(item.Calories, "[^0-9]", "");
                if(double.TryParse(mealCalories, out var amount))
                {
                    totalCalories += amount;
                }

            }
            totalCalories.Should().BeLessThanOrEqualTo(3000);
        }

        [Test]
        public void Get3Meals_ShouldReturnBreakfastLunchAndDinner()
        {
            //Arrange
            var request = new MealRequest();
            request.MaxCalories = 2000;
            var threeMealTypes = new List<MealType>()
                                    { MealType.Breakfast,
                                      MealType.Lunch,
                                      MealType.Dinner};

            var breakfastRecipes = GetMealResponse(new List<MealType> { MealType.Breakfast });
            var lunchRecipes = GetMealResponse(new List<MealType> { MealType.Lunch });
            var dinnerRecipes = GetMealResponse(new List<MealType> { MealType.Dinner });

            spoonacularService.SetupSequence(b => b.GetRecipes(It.IsAny<MealRequest>()))
                .Returns(breakfastRecipes)
                .Returns(lunchRecipes)
                .Returns(dinnerRecipes);

            //Act
            var result = mealService.Get3Meals(request);

            //Assert
            result.Select(m => m.Type).Except(threeMealTypes).Should().BeEmpty();
        }

        private MealResponse GetMealResponse(List<MealType> mealTypes)
        {
            var meals = new List<Meal>();
            if(mealTypes.Contains(MealType.Breakfast)|| mealTypes == null)
            {
                meals.Add(
                    new Meal()
                    {
                        Id = 1,
                        Title = "Toast and eggs",
                        Nutrition = new Nutrition()
                        {
                            Nutrients = new List<Nutrient>()
                            {
                                new Nutrient()
                                {
                                    Amount = 450,
                                    Name = "Calories",
                                    Unit = "kcal"
                                }
                            }
                        },
                    }
                    );
            }

            if (mealTypes.Contains(MealType.Lunch) || mealTypes == null)
            {
                meals.Add(
                    new Meal()
                    {
                        Id = 6,
                        Title = "Chicken Fajita Stuffed Bell Pepper",
                        Nutrition = new Nutrition()
                        {
                            Nutrients = new List<Nutrient>()
                            {
                                new Nutrient()
                                {
                                    Amount = 650,
                                    Name = "Calories",
                                    Unit = "kcal"
                                }
                            }
                        },
                    }
                    );
            }

            if (mealTypes.Contains(MealType.Dinner) || mealTypes == null)
            {
                meals.Add(
                    new Meal()
                    {
                        Id = 23,
                        Title = "Plantain Salad",
                        Nutrition = new Nutrition()
                        {
                            Nutrients = new List<Nutrient>()
                            {
                                new Nutrient()
                                {
                                    Amount = 600,
                                    Name = "Calories",
                                    Unit = "kcal"
                                }
                            }
                        },
                    }
                    );
            }


            return new MealResponse()
            {
                Meals = meals
            };
        }
    }
}
