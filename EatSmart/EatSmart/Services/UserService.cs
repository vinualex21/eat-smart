
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
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public User GetUserById(long id)
        {
            User user = new();

            try
            {
                user = _context.Users.First(v => v.UserId == id);
            }
            catch (Exception ex)
            {
                user = null;
            }
            return user;
        }

        public User? UpdateThisUser(long id, User user)
        {
            var existingUser = GetUserById(id);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.Surname = user.Surname;
                existingUser.MaxDailyCalories = user.MaxDailyCalories;
                existingUser.Intolerances = user.Intolerances;
                _context.SaveChanges();
                return user;
            }
            else
                return null;
        }
    }
}

