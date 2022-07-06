using EatSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatSmart.Services
{
    public interface IMealService
    {
        public List<MealDto> Get3Meals(MealRequest mealRequest);
    }
}
