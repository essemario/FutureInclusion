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
    public class EsferasController : ControllerBase
    {
        private readonly MySQLContext _context;

        public EsferasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Esferas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sphere>>> GetSphere()
        {
            return await _context.Sphere.ToListAsync();
        }

        // GET: api/Esferas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sphere>> GetSphere(uint id)
        {
            var sphere = await _context.Sphere.FindAsync(id);

            if (sphere == null)
            {
                return NotFound();
            }

            return sphere;
        }

        // PUT: api/Esferas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSphere(uint id, Sphere sphere)
        {
            if (id != sphere.Id)
            {
                return BadRequest();
            }

            _context.Entry(sphere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SphereExists(id))
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

        // POST: api/Esferas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sphere>> PostSphere(Sphere sphere)
        {
            _context.Sphere.Add(sphere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSphere", new { id = sphere.Id }, sphere);
        }

        // DELETE: api/Esferas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sphere>> DeleteSphere(uint id)
        {
            var sphere = await _context.Sphere.FindAsync(id);
            if (sphere == null)
            {
                return NotFound();
            }

            _context.Sphere.Remove(sphere);
            await _context.SaveChangesAsync();

            return sphere;
        }

        private bool SphereExists(uint id)
        {
            return _context.Sphere.Any(e => e.Id == id);
        }
    }
}
