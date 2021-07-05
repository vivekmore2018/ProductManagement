using System.ComponentModel.DataAnnotations;

namespace CM.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public string Description{get;set;}

        [Required(ErrorMessage = "Please enter price")]
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
