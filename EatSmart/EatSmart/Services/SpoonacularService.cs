using EatSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EatSmart.Services
{
    public class SpoonacularService : ISpoonacularService
    {
        private const string URL = "https://api.spoonacular.com/recipes/complexSearch";
        private string urlParameters = "?apiKey=118ce0b1c84a48289ee95470f5c344cf";

        public MealResponse GetRecipes(MealRequest mealRequest)
        {
            var mealDetails = new MealResponse();

            if (mealRequest == null)
                throw new ArgumentNullException(nameof(mealRequest), "No calories specified. Please enter the maximum calorie limit.");
            if (mealRequest.MaxCalories == 0)
                throw new ArgumentException("Invalid calorie input. Please enter a valid maximum calorie limit.");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringBuilder parameters = new StringBuilder(urlParameters);
            if (mealRequest.MaxCalories > 0)
                parameters.Append($"&maxCalories={mealRequest.MaxCalories}");
            if (mealRequest.MinCalories > 0)
                parameters.Append($"&minCalories={mealRequest.MinCalories}");
            if (mealRequest.Type != null)
                parameters.Append($"&type={mealRequest.Type.ToString()}");

            HttpResponseMessage response = client.GetAsync(parameters.ToString()).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                //var test = response.Content.ReadAsStringAsync();
                mealDetails = response.Content.ReadFromJsonAsync<MealResponse>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
            return mealDetails;
        }
    }
}
