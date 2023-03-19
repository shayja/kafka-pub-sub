namespace ApacheKafkaProducer.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using System.Threading.Tasks;
using ApacheKafkaProducer.Services;


[Route("api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{

    private readonly IApacheKafkaProducerService _apacheKafkaProducerService;
    public OrderController(IApacheKafkaProducerService apacheKafkaProducerService)
    {
        this._apacheKafkaProducerService = apacheKafkaProducerService ?? throw new NullReferenceException(nameof(apacheKafkaProducerService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
    {
        if (orderRequest is null) return BadRequest("Order is null");
        string message = JsonSerializer.Serialize(orderRequest);
        return Ok(await _apacheKafkaProducerService.SendOrderRequest(message));
    }


}