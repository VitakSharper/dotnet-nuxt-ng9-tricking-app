using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace TrickingLibrary.Api.Controllers
{
    [Route("api/videos")]
    public class VideosController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public VideosController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("{video}")]
        public IActionResult GetVideo(string video)
        {
            var mime = video.Split('.').Last();
            var savePath = Path.Combine(_environment.WebRootPath, video);
            return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), "video/*");
        }

        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile video)
        {
            var mime = video.FileName.Split('.').Last();
            // get path of wwwroot and random a file name , avoid to grab the origin filename;
            var fileName = string.Concat(Path.GetRandomFileName(), ".", mime);
            var savePath = Path.Combine(_environment.WebRootPath, fileName);

            await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            await video.CopyToAsync(fileStream);

            return Ok(fileName);
        }
    }
}