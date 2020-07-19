using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api.Controllers
{
    public class SubmissionsController : BaseController
    {
        private readonly AppDbContext _context;

        public SubmissionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Submission> All() => _context.Submissions.ToList();

        [HttpGet("{id}")]
        public Trick Get(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException();
            return _context.Tricks.FirstOrDefault(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        [HttpPost]
        public async Task<Trick> Create([FromBody] Trick submission)
        {
            _ = submission ?? throw new ArgumentNullException();

            _context.Add(submission);
            await _context.SaveChangesAsync();
            return submission;
        }

        [HttpPut]
        public IActionResult Update([FromBody] Trick submission)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            var submission = _context.Tricks.FirstOrDefault(t =>
                t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (submission == null) return BadRequest();

            submission.IsDeleted = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}