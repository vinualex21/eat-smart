using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatSmart.Models
{
    public class User
    {
        //[NotMapped]
        static string[] intoleranceList = {
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

        
        List<Intolerance> intolerances = new();

        [Key]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int MaxDailyCalories { get; set; }

        public List<Intolerance> Intolerances 
        { 
             get 
             {
                 return intolerances;
             }
             set
             {
                 foreach (var intolerance in value)
                     if (intoleranceList.Any(x => x == intolerance.name))
                         intolerances.Add(intolerance);
             }

         }

    }
}
