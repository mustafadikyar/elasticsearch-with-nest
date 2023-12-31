﻿using elasticsearch_nest_api.DTOs;

namespace elasticsearch_nest_api.Models;

public class Product
{
    [PropertyName("_id")]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public ProductDetail? Detail { get; set; }

    public ProductDTO CreateProductDTO()
    {
        if (Detail == null)
            return new ProductDTO(Id, Name, Price, Stock, null);

        return new ProductDTO(Id, Name, Price, Stock, new ProductDetailDTO(Detail.Width, Detail.Height));
    }
}
