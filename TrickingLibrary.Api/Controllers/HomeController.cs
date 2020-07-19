using Microsoft.AspNetCore.Mvc;

namespace TrickingLibrary.Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet("index")]
        public ActionResult Index() =>
            Ok("Some test!");
    }
}