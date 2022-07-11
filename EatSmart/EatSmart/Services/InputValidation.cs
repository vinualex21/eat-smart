using EatSmart.Models;
using System.Text.RegularExpressions;
using System;

namespace EatSmart.Services
{
    public class InputValidation : IInputValidation
    {
        public const int MIN_CALORIES = 1000;
        public const int MAX_CALORIES = 10000;
        
        public static string[] intoleranceList = {
            "Dairy",
            "Egg",
            "Gluten",
            "Grain",
            "Peanut",
            "Seafood",
            "Sesame",
            "Shellfish",
            "Soy",
            "Sulfite",
            "Tree_Nut2",
            "Wheat"
        };
      

        public string? ValidateUser(User user)
        {
            string alphaOnly = "^[a-zA-Z]*$";
            string commaSeparatedAlphaNumeric_ = "^([a-zA-Z_0-9]+,?)+$";

            if (!Regex.IsMatch(user.FirstName, alphaOnly))
                return "Invalid format for FirstName";

            if(!Regex.IsMatch(user.Surname, alphaOnly))
                return "Invalid format for Surname";

            if(user.Intolerances != "" )
            {
                if (!Regex.IsMatch(user.Intolerances, commaSeparatedAlphaNumeric_))
                    return "Invalid format for Intolerances";
                
                
                foreach (string intolerance in user.Intolerances.Split(','))
                    if (!intoleranceList.ToList().Contains(intolerance))
                        return $"Intolerance {intolerance} is not known";
                
            }

            if (user.MaxDailyCalories > MAX_CALORIES)
                return $"That's too many calories for one day! (Max: {MAX_CALORIES})";

            if(user.MaxDailyCalories < MIN_CALORIES)
                return $"That's too few calories for one day! (Min: {MIN_CALORIES})";

            return null;
        }


    }
}
