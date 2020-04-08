using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FutureInclusion.DataAccessLayer.Models;

namespace FutureInclusion.Web.Controllers
{
    public class EleitoresController : Controller
    {
        private readonly MySQLContext _context;

        public EleitoresController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Eleitores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voter.ToListAsync());
        }

        // GET: Eleitores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eleitores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Email,Password,Document,Enabled")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voter);
        }

        // GET: Eleitores/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voter = await _context.Voter.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }
            return View(voter);
        }

        // POST: Eleitores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name,LastName,Email,Password,Document,Enabled")] Voter voter)
        {
            if (id != voter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoterExists(voter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voter);
        }

        // GET: Eleitores/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var voter = await _context.Voter.FindAsync(id);
            _context.Voter.Remove(voter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoterExists(uint id)
        {
            return _context.Voter.Any(e => e.Id == id);
        }
    }
}
