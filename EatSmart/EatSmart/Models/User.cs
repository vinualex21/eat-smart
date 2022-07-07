using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EatSmart.Services;

namespace EatSmart.Models
{
    public class User
    {
  
        List<Intolerance> intolerances = new();

        [Key]
        public long UserId { get; private set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int MaxDailyCalories { get; set; }

        public List<Intolerance>? Intolerances { get; set; }
    
        public void SetUserId(long id)
        {
            UserId = id;
        }
    }
}
