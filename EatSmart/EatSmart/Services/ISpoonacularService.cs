using EatSmart.Models;

namespace EatSmart.Services
{
    public interface ISpoonacularService
    {
        public MealResponse GetRecipes(MealRequest recipeRequest);

    }
}
