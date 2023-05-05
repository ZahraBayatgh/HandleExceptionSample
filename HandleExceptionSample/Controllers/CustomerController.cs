using HandleExceptionSample.Contracts.Requests;
using HandleExceptionSample.Mapping;
using HandleExceptionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace HandleExceptionSample.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("customer")]
    public IActionResult Create([FromBody] CustomerRequest request)
    {
       var customer = _customerService.Create(request);

        var customerResponse = customer.ToCustomerResponse();

        return CreatedAtAction("Get", new { customerResponse.Email }, customerResponse);
    }

    [HttpGet("customer/{email}")]
    public  IActionResult Get([FromRoute] string email)
    {
        var customer =  _customerService.Get(email);

        if (customer is null)
        {
            return NotFound();
        }

        var customerResponse = customer.ToCustomerResponse();
        return Ok(customerResponse);
    }

}
