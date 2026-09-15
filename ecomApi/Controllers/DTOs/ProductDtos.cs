namespace ecomApi.Controllers.DTOs
{
    public class ProductDtos
    {
        public string ProductName { get; set; } = string.Empty;
      
        public string ShortName { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public  string? Description { get; set; }    
    }
}
