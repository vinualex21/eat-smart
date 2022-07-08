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
<<<<<<< HEAD
        public DbSet<Intolerance> Intolerances { get; set; }
        public DbSet<MealRequest> MealRequests { get; set; }

=======
       
>>>>>>> 2ea1774a218117c781236ea65400d187eb5a01af
    }
}

