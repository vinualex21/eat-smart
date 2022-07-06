using System.ComponentModel.DataAnnotations;

namespace EatSmart.Models
{
    public class Intolerance
    {
      
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
