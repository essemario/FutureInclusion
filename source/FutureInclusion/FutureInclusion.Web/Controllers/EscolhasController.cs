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
    public class EscolhasController : Controller
    {
        private readonly MySQLContext _context;

        public EscolhasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Escolhas
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.Choice.Include(c => c.Poll);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Escolhas/Create
        public IActionResult Create()
        {
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description");
            return View();
        }

        // POST: Escolhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,PollId")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", choice.PollId);
            return View(choice);
        }

        // GET: Escolhas/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choice = await _context.Choice.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", choice.PollId);
            return View(choice);
        }

        // POST: Escolhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Text,PollId")] Choice choice)
        {
            if (id != choice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(choice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoiceExists(choice.Id))
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
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", choice.PollId);
            return View(choice);
        }

        // GET: Escolhas/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var choice = await _context.Choice.FindAsync(id);
            _context.Choice.Remove(choice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoiceExists(uint id)
        {
            return _context.Choice.Any(e => e.Id == id);
        }
    }
}
