using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        [Required,
        MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required,
        DataType(DataType.Date),
        Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; }

        [Required,
        DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required]
        public string Author { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
    }
}