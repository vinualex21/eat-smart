using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatSmart.Models
{
    public class MealDto : MealBase
    {
        public double Calories { get; set; }
        public string Carbs { get; set; }
        public string Fat { get; set; }
        public string Protein { get; set; }
    }
}
