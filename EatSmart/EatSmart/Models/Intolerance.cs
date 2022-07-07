using System.ComponentModel.DataAnnotations;

namespace EatSmart.Models
{
    public class Intolerance
    {
      
        [Key]
        public int id { get; private set; }
        public string name { get; set; }
    }
}
