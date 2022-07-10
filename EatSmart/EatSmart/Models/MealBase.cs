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
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyOrder(1)]
        public string Title { get; set; }
        [JsonPropertyOrder(0)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MealType Type { get; set; }
    }
}
