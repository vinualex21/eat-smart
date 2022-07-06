using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EatSmart.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nutrition Nutrition { get; set; }
    }

    public class Nutrition
    {
        public IEnumerable<Nutrient> Nutrients { get; set; }
    }

    public class Nutrient
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }


    public class MealResponse
    {
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("results")]
        public IEnumerable<Meal> Meals { get; set; }
    }

}
