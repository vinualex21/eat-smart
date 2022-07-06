using System;
using Microsoft.EntityFrameworkCore;

namespace EatSmart.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Intolerance> Intolerances { get; set; }
       
    }
}

