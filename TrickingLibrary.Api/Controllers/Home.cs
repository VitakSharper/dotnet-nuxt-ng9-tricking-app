using Microsoft.AspNetCore.Mvc;

namespace TrickingLibrary.Api.Controllers
{
    public class Home : Base
    {
        [HttpGet("index")]
        public ActionResult Index()
        {
            return Ok("Some test!");
        }
    }
}