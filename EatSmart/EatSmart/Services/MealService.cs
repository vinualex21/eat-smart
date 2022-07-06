using EatSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatSmart.Services
{
    public class MealService
    {
        private ISpoonacularService spoonacularService;

        public MealService(ISpoonacularService _spoonacularService)
        {
            spoonacularService = _spoonacularService;
        }

        public List<MealDto> Get3Meals(MealRequest mealRequest)
        {
            var meals = new List<MealDto>();
            var totalCalories = mealRequest.MaxCalories;

            mealRequest.Type = MealType.Breakfast;
            mealRequest.MaxCalories = totalCalories / 3;
            mealRequest.MinCalories = mealRequest.MaxCalories * 0.5;
            var availableBreakfast = spoonacularService.GetRecipes(mealRequest).Meals.ToList();
            if (availableBreakfast.Count() > 0)
            {
                var breakfast = ConvertToMealDto(GetRandomMeal(availableBreakfast));
                breakfast.Type = MealType.Breakfast;
                meals.Add(breakfast);
            }

            mealRequest.Type = MealType.MainCourse;
            mealRequest.MaxCalories = totalCalories / 3;
            mealRequest.MinCalories = mealRequest.MaxCalories * 0.5;
            var availableLunch = spoonacularService.GetRecipes(mealRequest).Meals.ToList();
            if (availableLunch.Count() > 0)
            {
                var lunch = ConvertToMealDto(GetRandomMeal(availableLunch));
                lunch.Type = MealType.Lunch;
                meals.Add(lunch);
            }

            mealRequest.Type = MealType.MainCourse;
            mealRequest.MaxCalories = totalCalories / 3;
            mealRequest.MinCalories = mealRequest.MaxCalories * 0.5;
            var availableDinner = spoonacularService.GetRecipes(mealRequest).Meals.ToList();
            if (availableDinner.Count() > 0)
            {
                var dinner = ConvertToMealDto(GetRandomMeal(availableDinner));
                dinner.Type = MealType.Dinner;
                meals.Add(dinner);
            }

            return meals;
        }

        private Meal GetRandomMeal(List<Meal> meals)
        {
            var rand = new Random();
            return meals.Any() ? meals.ElementAt(rand.Next(meals.Count())) : null;
        }

        private MealDto ConvertToMealDto(Meal mealModel)
        {
            var mealDto = new MealDto()
            {
                Id = mealModel.Id,
                Title = mealModel.Title,
                Calories = mealModel.Nutrition?.Nutrients?.SingleOrDefault(n => n.Name == "Calories")?.Amount ?? 0,
            };

            return mealDto;
        }
    }
}
