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
    public class EleitoresController : ControllerBase
    {
        private readonly MySQLContext _context;

        public EleitoresController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Eleitores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetVoter()
        {
            return await _context.Voter.Include(v => v.MandateVoter).ToListAsync();
        }

        // GET: api/Eleitores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> GetVoter(uint id)
        {
            var voter = await _context.Voter.Include(v => v.MandateVoter).FirstOrDefaultAsync(i => i.Id == id);
            //var voter = await _context.Voter.FindAsync(id);

            if (voter == null)
            {
                return NotFound();
            }

            return voter;
        }

        // PUT: api/Eleitores/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoter(uint id, Voter voter)
        {
            if (id != voter.Id)
            {
                return BadRequest();
            }

            _context.Entry(voter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(id))
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

        // POST: api/Eleitores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Voter>> PostVoter(Voter voter)
        {
            _context.Voter.Add(voter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoter", new { id = voter.Id }, voter);
        }

        // DELETE: api/Eleitores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voter>> DeleteVoter(uint id)
        {
            var voter = await _context.Voter.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }

            _context.Voter.Remove(voter);
            await _context.SaveChangesAsync();

            return voter;
        }

        private bool VoterExists(uint id)
        {
            return _context.Voter.Any(e => e.Id == id);
        }
    }
}
