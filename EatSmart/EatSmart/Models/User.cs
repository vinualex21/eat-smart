using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EatSmart.Services;

namespace EatSmart.Models
{
    public class User
    {
        public User(long userId)
        {
            UserId = userId;
        }

        public User()
        {

        }
        [Key]
        public long UserId { get; private set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int MaxDailyCalories { get; set; }

        public string? Intolerances { get; set; }
    
  
    }
}
