namespace ApacheKafkaProducer.Controllers.v2;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class OrderController : ControllerBase
{

    private readonly IApacheKafkaProducerService _apacheKafkaProducerService;
    public OrderController(IApacheKafkaProducerService apacheKafkaProducerService)
    {
        this._apacheKafkaProducerService = apacheKafkaProducerService ?? throw new ArgumentNullException(nameof(apacheKafkaProducerService));
    }

    //[MapToApiVersion("2.0")]
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderRequest? orderRequest, CancellationToken cancellation = default)
    {
        if (orderRequest is null) return BadRequest("Order is null");
        var message = JsonSerializer.Serialize(orderRequest);
        var res = await _apacheKafkaProducerService.SendOrderRequest(message, cancellation).ConfigureAwait(false);
        return Ok(res);
    }


}