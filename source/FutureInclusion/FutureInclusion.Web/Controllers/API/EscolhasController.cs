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
    public class EscolhasController : ControllerBase
    {
        private readonly MySQLContext _context;

        public EscolhasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: api/Escolhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Choice>>> GetChoice()
        {
            return await _context.Choice.ToListAsync();
        }

        // GET: api/Escolhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Choice>> GetChoice(uint id)
        {
            var choice = await _context.Choice.FindAsync(id);

            if (choice == null)
            {
                return NotFound();
            }

            return choice;
        }

        // PUT: api/Escolhas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChoice(uint id, Choice choice)
        {
            if (id != choice.Id)
            {
                return BadRequest();
            }

            _context.Entry(choice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoiceExists(id))
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

        // POST: api/Escolhas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Choice>> PostChoice(Choice choice)
        {
            _context.Choice.Add(choice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChoice", new { id = choice.Id }, choice);
        }

        // DELETE: api/Escolhas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Choice>> DeleteChoice(uint id)
        {
            var choice = await _context.Choice.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }

            _context.Choice.Remove(choice);
            await _context.SaveChangesAsync();

            return choice;
        }

        private bool ChoiceExists(uint id)
        {
            return _context.Choice.Any(e => e.Id == id);
        }
    }
}
