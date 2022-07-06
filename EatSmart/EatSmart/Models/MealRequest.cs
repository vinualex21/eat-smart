using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatSmart.Models
{
    public class MealRequest : MealBase
    {
        public double MinCalories { get; set; }
        public double MaxCalories { get; set; }
        public string Intolerances { get; set; }
        public int Offset { get; set; }
        public int Number { get; set; }
    }
}
