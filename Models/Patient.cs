using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class Patient : Person
    {
        [Key]
        [DisplayName("ID")]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Disease")]
        public string disease {  get; set; }

        [Required]
        [DisplayName("Symptoms")]
        public string Description { get; set; }
    }
}
