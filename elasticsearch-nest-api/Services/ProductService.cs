using System.Collections.Immutable;

namespace elasticsearch_nest_api.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO?> InsertAsync(ProductCreateDTO request)
    {
        var response = await _productRepository.InsertAsync(request.CreateProduct());

        if (response == null)
            return null;

        return response.CreateProductDTO();
    }

    public async Task<ImmutableList<ProductDTO>> GetAllAsync()
    {
        var response = await _productRepository.GetAllAsync();
        return response.Select(c=> new ProductDTO(c.Id, c.Name, c.Price, c.Stock, new ProductDetailDTO(c.Detail!.Width, c.Detail!.Height))).ToImmutableList();
    }
}
