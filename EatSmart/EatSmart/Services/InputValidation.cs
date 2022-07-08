using EatSmart.Models;
using System.Text.RegularExpressions;
using System;

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
        bool ValidateIntolerance(string intolerance)
        {
            return intoleranceList.ToList().Contains(intolerance);
      
        }

        public string? ValidateUser(User user)
        {
            string alphaOnly = "^[a-zA-Z]*$";
            string commaSeparatedAlpha = "^([a-zA-Z]?,?)*$";

            if (!Regex.IsMatch(user.FirstName, alphaOnly))
                return "Invalid format for FirstName";
            else if(!Regex.IsMatch(user.Surname, alphaOnly))
                return "Invalid format for Surname";
            else if(user.Intolerances != "" )
            {
                if (!Regex.IsMatch(user.Intolerances, commaSeparatedAlpha))
                    return "Invalid format for Intolerances";
                else
                {
                    foreach (string intolerance in user.Intolerances.Split(','))
                        if (!ValidateIntolerance(intolerance))
                            return $"Intolerance {intolerance} is not known";
                }
            }
            return null;
        }


    }
}
