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
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

 

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public object FindUserById(long id)
        {
            User _user = _userService.GetUserById(id);
            if (_user != null)
                return Accepted(_user);
            else
                return NotFound(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public object CreateNewUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtAction(nameof(FindUserById), new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public object UpdateUser(long id, User user)
        {
            User _user = _userService.UpdateThisUser(id, user);
            if (_user != null)
                return Accepted(_user);
            else
                return NotFound(id);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public object DeleteUser(long id)
        {
            if (_userService.DeleteThisUser(id))
                return Accepted(id);
            else
                return NotFound(id);
                

        }
    }
}
