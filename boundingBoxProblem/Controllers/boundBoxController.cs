using boundingBoxProblem.Business;
using boundingBoxProblem.DataModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace boundingBoxProblem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class boundBoxController : ControllerBase
    {
       

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<wordsBoundBoxDataModel> value)
        {
            try
            {
                var result= boundBoxBusiness.boundBoxHandler(value);

                return CreatedAtAction(nameof(Post) , new
                {
                    status = "success",
                    message = "Data returned successfully",
                    data = result
                });
            }

            catch (Exception ex) {
                return StatusCode(500, new { status = "error", message = "An unexpected error occurred.", details = ex.Message });

            }
        }

      
        
    }
}
