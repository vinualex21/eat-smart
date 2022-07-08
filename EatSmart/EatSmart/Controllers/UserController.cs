using Microsoft.AspNetCore.Mvc;
using EatSmart.Services;
using EatSmart.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EatSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IInputValidation _inputValidation;
        public UserController(IUserService userService, IInputValidation inputValidation)
        {
            _userService = userService;
            _inputValidation = inputValidation;
        }

 

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> FindUserById(long id)
        {
            User _user = _userService.GetUserById(id);
            if (_user != null)
                return _user;
            else
                return NotFound($"User with Id {id} is not in the database");
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult CreateNewUser(User user)
        {
            string? result = _inputValidation.ValidateUser(user);
            if ( result == null)
            {
                _userService.CreateUser(user);
                return CreatedAtAction(nameof(FindUserById), new { id = user.UserId }, user);
            }
            else
            {
                return ValidationProblem(result);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(long id, User user)
        {
            string? result = _inputValidation.ValidateUser(user);

            if (result == null)
            {
                User _user = _userService.UpdateThisUser(id, user);
                if (_user != null)
                    return _user;
                else
                    return NotFound($"User with Id {id} is not in the database");
            }
            else
                return ValidationProblem(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            if (_userService.DeleteThisUser(id))
                return Accepted($"User with Id {id} has been deleted");
            else
                return NotFound($"User with Id {id} is not in the database");
                

        }
    }
}
