using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EatSmart.Models
{
    public class MealDto : MealBase
    {
        [JsonPropertyOrder(2)]
        public double Calories { get; set; }
        [JsonPropertyOrder(3)]
        public string Carbs { get; set; }
        [JsonPropertyOrder(4)]
        public string Fat { get; set; }
        [JsonPropertyOrder(5)]
        public string Protein { get; set; }
    }
}
