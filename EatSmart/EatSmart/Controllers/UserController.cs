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

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> FindUserById(long id)
        {
            
            return _userService.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> CreateNewUser(User user)
        {
            return _userService.CreateUser(user);
            //return CreatedAtAction(nameof(FindUserById), new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(long id, User user)
        {
            return _userService.UpdateThisUser(id, user);
            //return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteUser(long id)
        {
            if(_userService.DeleteThisUser(id))
                return $"User with UserID {id} deleted";
            else
                return $"User with UserID {id} not found";
        
        }
    }
}
