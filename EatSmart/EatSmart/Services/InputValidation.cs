using EatSmart.Models;
using System.Text.RegularExpressions;

namespace EatSmart.Services
{
    public class InputValidation : IInputValidation
    {
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
        bool ValidateIntolerance(Intolerance intolerance)
        {
            return intoleranceList.ToList().Contains(intolerance.name);
      
        }

        public string? ValidateUser(User user)
        {
            string alphaOnly = "^[a-zA-Z]*$";

            if (!Regex.IsMatch(user.FirstName, alphaOnly))
                return "Invalid format for FirstName";
            else if(!Regex.IsMatch(user.Surname, alphaOnly))
                return "Invalid format for Surname";
            else
            {
                foreach (Intolerance intolerance in user.Intolerances)
                    if (!ValidateIntolerance(intolerance))
                        return $"Intolerance {intolerance} is not known";
            }
            return null;
        }


    }
}
