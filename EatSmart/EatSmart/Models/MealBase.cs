using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatSmart.Models
{
    public class MealBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MealType Type { get; set; }
    }
}
