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
}
