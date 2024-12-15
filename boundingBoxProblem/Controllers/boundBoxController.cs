using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace boundingBoxProblem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class boundBoxController : ControllerBase
    {
       

        [HttpPost]
        public string Post([FromBody] string value)
        {
            throw new Exception("test");
            return value;
        }

      
        
    }
}
