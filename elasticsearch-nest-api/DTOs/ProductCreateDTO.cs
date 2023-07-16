namespace elasticsearch_nest_api.DTOs;

public record ProductCreateDTO(string name, decimal price, int stock, ProductDetailDTO detail)
{
    public Product CreateProduct() => new Product
    {
        Name = name,
        Price = price,
        Stock = stock,
        Detail = new ProductDetail
        {
            Width = detail.width,
            Height = detail.height
        }
    };
}
