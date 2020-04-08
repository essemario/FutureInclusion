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
    public class PesquisasController : Controller
    {
        private readonly MySQLContext _context;

        public PesquisasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Pesquisas
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.Poll.Include(p => p.Mandate);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Pesquisas/Create
        public IActionResult Create()
        {
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title");
            return View();
        }

        // POST: Pesquisas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Start,End,Description,Tag,MandateId")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", poll.MandateId);
            return View(poll);
        }

        // GET: Pesquisas/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", poll.MandateId);
            return View(poll);
        }

        // POST: Pesquisas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name,Start,End,Description,Tag,MandateId")] Poll poll)
        {
            if (id != poll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollExists(poll.Id))
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
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", poll.MandateId);
            return View(poll);
        }

        // GET: Pesquisas/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll.FindAsync(id);
            _context.Poll.Remove(poll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollExists(uint id)
        {
            return _context.Poll.Any(e => e.Id == id);
        }
    }
}
