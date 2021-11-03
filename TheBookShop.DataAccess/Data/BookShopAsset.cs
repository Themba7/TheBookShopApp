using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBookShop.DataAccess.Data
{
    public class BookShopAsset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public string Language { get; set; }
        public string ISNB { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
