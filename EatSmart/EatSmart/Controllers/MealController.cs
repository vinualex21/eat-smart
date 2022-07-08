﻿using System;
using Microsoft.AspNetCore.Mvc;
using EatSmart.Services;
using EatSmart.Models;
using System.Linq;
using System.Text;

namespace EatSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        private readonly IUserService _userService;
        public MealController(IMealService mealService, IUserService userService)
        {
            _mealService = mealService;
            _userService = userService;
        }

        // GET api/<MealController>/
        [HttpGet("{id}")]
        public ActionResult<List<MealDto>> GetMeals(long id)
        {
            User _user = _userService.GetUserById(id);
            string Intolerances = string.Join(",", _user.Intolerances);

            MealRequest _mealRequest = new MealRequest();
            _mealRequest.MaxCalories = _user.MaxDailyCalories;
            _mealRequest.Intolerances = Intolerances;

            var meals = new List<MealDto>();
            meals =  _mealService.Get3Meals(_mealRequest);

            return meals;
         
        }
    }
}

