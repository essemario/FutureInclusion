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
    public class MandatosController : ControllerBase
    {
        private readonly MySQLContext _context;

        public MandatosController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Mandatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mandate>>> GetMandate()
        {
            return await _context.Mandate.ToListAsync();
        }

        // GET: api/Mandatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mandate>> GetMandate(uint id)
        {
            var mandate = await _context.Mandate.FindAsync(id);

            if (mandate == null)
            {
                return NotFound();
            }

            return mandate;
        }

        // PUT: api/Mandatos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandate(uint id, Mandate mandate)
        {
            if (id != mandate.Id)
            {
                return BadRequest();
            }

            _context.Entry(mandate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MandateExists(id))
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

        // POST: api/Mandatos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mandate>> PostMandate(Mandate mandate)
        {
            _context.Mandate.Add(mandate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMandate", new { id = mandate.Id }, mandate);
        }

        // DELETE: api/Mandatos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mandate>> DeleteMandate(uint id)
        {
            var mandate = await _context.Mandate.FindAsync(id);
            if (mandate == null)
            {
                return NotFound();
            }

            _context.Mandate.Remove(mandate);
            await _context.SaveChangesAsync();

            return mandate;
        }

        private bool MandateExists(uint id)
        {
            return _context.Mandate.Any(e => e.Id == id);
        }
    }
}
