using System.ComponentModel.DataAnnotations;

namespace MediKeeper.API.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }

    }
}
