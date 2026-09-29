namespace ecomApi.Controllers.DTOs
{
    public class ProductDtos
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
      
        public string? ShortName { get; set; }
        public Decimal? Price { get; set; }
        public  string? Description { get; set; }    
    }
}
