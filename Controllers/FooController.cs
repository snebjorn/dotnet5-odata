using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace dotnet5_odata.Controllers
{
    [Route("odata/foos")]
    public class FooController : ODataController
    {
        public FooController()
        {
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return BadRequest("Baddy bad bad!");
        }
    }
}
