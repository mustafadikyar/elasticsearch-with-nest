using System.Collections.Immutable;

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
        var response = await _elasticsearchClient.IndexAsync(product, c => c.Index(index: "products").Id(Guid.NewGuid().ToString()));

        if (response != null)
            return null;

        product.Id = response!.Id;
        return product;
    }

    public async Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        var response = await _elasticsearchClient
            .SearchAsync<Product>(c => c.Index("products")
            .Query(c => c.MatchAll()));

        foreach(var hit in response.Hits) 
            hit.Source.Id = hit.Id;

        return response.Documents.ToImmutableList(); //listede bir değişiklik yapılamaz
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        var response = await _elasticsearchClient.GetAsync<Product>(id, c => c.Index(index: "products"));

        if(!response.IsValid)
            return null;

        response.Source.Id = response!.Id;

        return response.Source;
    }

    public async Task<bool> UpdateAsync(ProductUpdateDTO request)
    {
        var response = await _elasticsearchClient.UpdateAsync<Product, ProductUpdateDTO>(request.id,c=> c.Index("products").Doc(request));
        return response.IsValid;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _elasticsearchClient.DeleteAsync<Product>(id, c => c.Index(index: "products"));
        return response.IsValid;
    }
}