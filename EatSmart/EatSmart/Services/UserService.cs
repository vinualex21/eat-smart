
using System;
using EatSmart.Models;

namespace EatSmart.Services
{
    public class UserService : IUserService
    {

        private UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteThisUser(long id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public User GetUserById(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            else return user;
        }

        public long GetUserId(string name)
        {
            var user = _context.Users.Find(name);
            return user.UserId;
        }

        public User UpdateThisUser(long id, User user)
        {
            var existinguser = GetUserById(id);

            existinguser.Name = user.Name;
           
            _context.SaveChanges();
            return user;
        }
    }
}

