using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FutureInclusion.DataAccessLayer.Models;

namespace FutureInclusion.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisasController : ControllerBase
    {
        private readonly MySQLContext _context;

        public PesquisasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Pesquisas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPoll()
        {
            return await _context.Poll.ToListAsync();
        }

        // GET: api/Pesquisas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> GetPoll(uint id)
        {
            var poll = await _context.Poll.FindAsync(id);

            if (poll == null)
            {
                return NotFound();
            }

            return poll;
        }

        // PUT: api/Pesquisas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(uint id, Poll poll)
        {
            if (id != poll.Id)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pesquisas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Poll>> PostPoll(Poll poll)
        {
            _context.Poll.Add(poll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoll", new { id = poll.Id }, poll);
        }

        // DELETE: api/Pesquisas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poll>> DeletePoll(uint id)
        {
            var poll = await _context.Poll.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Poll.Remove(poll);
            await _context.SaveChangesAsync();

            return poll;
        }

        private bool PollExists(uint id)
        {
            return _context.Poll.Any(e => e.Id == id);
        }
    }
}
