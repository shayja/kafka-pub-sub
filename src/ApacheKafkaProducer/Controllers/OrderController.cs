namespace ApacheKafkaProducer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Text.Json;
using System.Threading.Tasks;


[Route("api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{

    private readonly IApacheKafkaProducerService _apacheKafkaProducerService;
    public OrderController(IApacheKafkaProducerService apacheKafkaProducerService)
    {
        this._apacheKafkaProducerService = apacheKafkaProducerService ?? throw new ArgumentNullException(nameof(apacheKafkaProducerService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderRequest? orderRequest, CancellationToken cancellation = default)
    {
        if (orderRequest is null) return BadRequest("Order is null");
        var message = JsonSerializer.Serialize(orderRequest);
        var res = await _apacheKafkaProducerService.SendOrderRequest(message, cancellation).ConfigureAwait(false);
        return Ok(res);
    }


}