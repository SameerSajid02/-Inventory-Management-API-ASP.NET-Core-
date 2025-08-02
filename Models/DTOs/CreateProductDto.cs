namespace ProductInventoryApi.Models.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
