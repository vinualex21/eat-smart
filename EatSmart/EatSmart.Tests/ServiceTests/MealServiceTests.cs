using EatSmart.Models;
using EatSmart.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EatSmart.Tests.ServiceTests
{
    public class MealServiceTests
    {
        private Mock<ISpoonacularService> spoonacularService;
        private MealService mealService;
        private UserContext mealRequestContext;


        [SetUp]
        public void Setup()
        {
            spoonacularService= new Mock<ISpoonacularService>();
            mealService = new MealService(spoonacularService.Object,mealRequestContext);
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
            result.Sum(m => m.Calories).Should().BeLessThanOrEqualTo(3000);
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

            if (mealTypes.Contains(MealType.Breakfast) || mealTypes == null)
            {
                meals.Add(
                    new Meal()
                    {
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
