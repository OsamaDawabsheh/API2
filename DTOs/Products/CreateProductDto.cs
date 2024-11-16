using System.ComponentModel.DataAnnotations;

namespace API2.DTOs.Products
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Name can't be empty")]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters")]
        [MaxLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price can't be empty")]
        [Range(20, 3000, ErrorMessage = "Price must be between 20 and 3000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description can't be empty")]
        [MinLength(10, ErrorMessage = "Name must be at least 10 characters")]
        public string Description { get; set; }
    }
}
