using System;
using Microsoft.EntityFrameworkCore;

namespace EatSmart.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
       
        public DbSet<User> Users { get; set; }

        public DbSet<MealRequest> MealRequests { get; set; }

    }
}

