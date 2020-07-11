using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api.Controllers
{
    public class TricksController : Base
    {
        private readonly TrickyStore _trickyStore;

        public TricksController(TrickyStore trickyStore)
        {
            _trickyStore = trickyStore;
        }

        [HttpGet]
        public IActionResult All() => Ok(_trickyStore.All);

        [HttpGet("{id}")]
        public IActionResult Get(string id) => Ok(_trickyStore.All.FirstOrDefault(t => t.Id.Equals(id)));

        [HttpPost]
        public IActionResult Create([FromBody] Trick trick)
        {
            if (trick == null) return BadRequest();
            if (string.IsNullOrEmpty(trick.Name)) return NotFound();
            _trickyStore.Add(trick);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Trick trick)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] string id)
        {
            return NoContent();
        }
    }
}