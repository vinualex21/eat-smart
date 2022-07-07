
using System;
using EatSmart.Models;
using Microsoft.EntityFrameworkCore;

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
            var user = GetUserById(id);

            if (user != null)
            {
                foreach(Intolerance i in user.Intolerances)
                    _context.Intolerances.Remove(i);

                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public User GetUserById(long id)
        {
            User user = _context.Users.Include(u => u.Intolerances).First(v => v.UserId == id);

            return user;
        }

        public User? UpdateThisUser(long id, User user)
        {
            if(DeleteThisUser(id))
            {
                user.SetUserId(id);
                CreateUser(user);
                return user;
            }
            else
                return null;
        }
    }
}

