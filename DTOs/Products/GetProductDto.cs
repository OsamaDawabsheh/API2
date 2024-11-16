using System.ComponentModel.DataAnnotations;

namespace API2.DTOs.Products
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
