namespace elasticsearch_nest_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductCreateDTO request)
        => Ok(await _productService.InsertAsync(request));

    [HttpGet]
    public async Task<IActionResult> GetAll()
       => Ok(await _productService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAll(string id)
      => Ok(await _productService.GetByIdAsync(id));

    [HttpPut]
    public async Task<IActionResult> Put(ProductUpdateDTO request)
       => Ok(await _productService.UpdateAsync(request));
}
