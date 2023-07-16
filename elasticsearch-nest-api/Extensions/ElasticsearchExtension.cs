namespace elasticsearch_nest_api.Extensions;

public static class ElasticsearchExtension
{
    public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
    {
        var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
        var setting = new ConnectionSettings(pool);
        var client = new ElasticClient(setting);
        services.AddSingleton(client);
    }
}
