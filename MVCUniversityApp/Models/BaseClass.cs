using System.ComponentModel.DataAnnotations;

namespace MVCUniversityApp.Models
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5)]
        public string Name { get; set; }
    }
}
