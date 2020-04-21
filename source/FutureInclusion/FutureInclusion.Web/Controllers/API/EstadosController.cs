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
    public class EstadosController : ControllerBase
    {
        private readonly MySQLContext _context;

        public EstadosController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetState()
        {
            return await _context.State.Include(s => s.City).Include(c => c.Country).ToListAsync();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(uint id)
        {
            var state = await _context.State.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(uint id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/Estados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            _context.State.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.Id }, state);
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<State>> DeleteState(uint id)
        {
            var state = await _context.State.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.State.Remove(state);
            await _context.SaveChangesAsync();

            return state;
        }

        private bool StateExists(uint id)
        {
            return _context.State.Any(e => e.Id == id);
        }
    }
}
