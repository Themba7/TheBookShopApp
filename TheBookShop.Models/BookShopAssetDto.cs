using System.ComponentModel.DataAnnotations;

namespace TheBookShop.Models
{
    public class BookShopAssetDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
