using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api.Controllers
{
    public class TricksController : BaseController
    {
        private readonly AppDbContext _context;

        public TricksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Trick> All() => _context.Tricks.ToList();

        [HttpGet("{id}")]
        public Trick Get(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException();
            return _context.Tricks.FirstOrDefault(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet("{trickId}/submissions")]
        public IEnumerable<Submission> ListSubmissionsForTrick(string trickId)
        {
            if (string.IsNullOrEmpty(trickId)) throw new ArgumentNullException();
            return _context.Submissions.Where(s =>
                s.Id.Equals(trickId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        [HttpPost]
        public async Task<Trick> Create([FromBody] Trick trick)
        {
            _ = trick ?? throw new ArgumentNullException();

            _context.Add(trick);
            await _context.SaveChangesAsync();
            return trick;
        }

        [HttpPut]
        public IActionResult Update([FromBody] Trick trick)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            var trick = _context.Tricks.FirstOrDefault(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (trick == null) return BadRequest();

            trick.IsDeleted = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}