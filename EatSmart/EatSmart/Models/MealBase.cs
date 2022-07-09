using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EatSmart.Models
{
    public class MealBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MealType Type { get; set; }
    }
}
