using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController: ControllerBase
{
    HellowordService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger,HellowordService helloWorldServices )
    {
        helloWorldService = helloWorldServices;
        _logger= logger;
        
    }
    
    [HttpGet]
    public IActionResult Get(){
        _logger.LogInformation("Devolviendo hello world");
        return Ok(helloWorldService.GetHelloWord());
    }


}


// using Microsoft.AspNetCore.Mvc;

// namespace mywebapi.Controllers;

// [ApiController]
// [Route("api/v1/[controller]")]
// public class HelloWorldController : ControllerBase{

//     IHelloWorldService helloWorldService;
//     private readonly ILogger<HelloWorldController> _logger;
//     public HelloWorldController(ILogger<HelloWorldController> logger,IHelloWorldService helloworld)
//     {
//         _logger = logger;
//         helloWorldService = helloworld;
//     }

//     public IActionResult Get()
//     {
//         _logger.LogInformation("Saludando el mundo");
//         return Ok(helloWorldService.GetHelloWorld()); 
//     }
// }