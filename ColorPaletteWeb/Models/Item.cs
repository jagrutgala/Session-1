using System.ComponentModel.DataAnnotations;

namespace ColorPaletteWeb.Models
{
    public class Item
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
