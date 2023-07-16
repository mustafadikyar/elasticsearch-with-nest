namespace elasticsearch_nest_api.Repositories;

public class ProductRepository
{
    private readonly ElasticClient _elasticsearchClient;
    public ProductRepository(ElasticClient elasticsearchClient)
    {
        _elasticsearchClient = elasticsearchClient;
    }

    public async Task<Product?> InsertAsync(Product product)
    {
        product.Created = DateTime.Now;
        var response = await _elasticsearchClient.IndexAsync(product, c => c.Index("products").Id(Guid.NewGuid().ToString()));

        if (response != null) 
            return null;

        product.Id = response!.Id;
        return product;
    }
}
