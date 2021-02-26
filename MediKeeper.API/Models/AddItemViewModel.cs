using System.ComponentModel.DataAnnotations;

namespace MediKeeper.API.Models
{
    public class AddItemViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive cost allowed")]
        public decimal Cost { get; set; }
    }
}