using System.ComponentModel.DataAnnotations;

namespace MVCUniversityApp.Models
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
