namespace elasticsearch_nest_api.DTOs
{
    public record ProductDTO(string id, string name, decimal price, int stock, ProductDetailDTO? detail)
    {     
    }
}
