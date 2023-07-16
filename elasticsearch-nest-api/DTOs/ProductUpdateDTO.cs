namespace elasticsearch_nest_api.DTOs
{
    public record ProductUpdateDTO(string id, string name, decimal price, int stock, ProductDetailDTO detail)
    {
    }
}
