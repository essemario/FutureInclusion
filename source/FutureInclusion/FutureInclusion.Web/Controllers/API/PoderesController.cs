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
    public class PoderesController : ControllerBase
    {
        private readonly MySQLContext _context;

        public PoderesController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Poderes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Power>>> GetPower()
        {
            return await _context.Power.ToListAsync();
        }

        // GET: api/Poderes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> GetPower(uint id)
        {
            var power = await _context.Power.FindAsync(id);

            if (power == null)
            {
                return NotFound();
            }

            return power;
        }

        // PUT: api/Poderes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPower(uint id, Power power)
        {
            if (id != power.Id)
            {
                return BadRequest();
            }

            _context.Entry(power).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowerExists(id))
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

        // POST: api/Poderes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Power>> PostPower(Power power)
        {
            _context.Power.Add(power);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPower", new { id = power.Id }, power);
        }

        // DELETE: api/Poderes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Power>> DeletePower(uint id)
        {
            var power = await _context.Power.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            _context.Power.Remove(power);
            await _context.SaveChangesAsync();

            return power;
        }

        private bool PowerExists(uint id)
        {
            return _context.Power.Any(e => e.Id == id);
        }
    }
}
