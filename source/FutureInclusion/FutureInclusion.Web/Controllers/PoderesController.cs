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
    public class PoderesController : Controller
    {
        private readonly MySQLContext _context;

        public PoderesController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Poderes
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.Power.Include(p => p.Sphere);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Poderes/Create
        public IActionResult Create()
        {
            ViewData["SphereId"] = new SelectList(_context.Sphere, "Id", "Name");
            return View();
        }

        // POST: Poderes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SphereId")] Power power)
        {
            if (ModelState.IsValid)
            {
                _context.Add(power);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SphereId"] = new SelectList(_context.Sphere, "Id", "Name", power.SphereId);
            return View(power);
        }

        // GET: Poderes/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _context.Power.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }
            ViewData["SphereId"] = new SelectList(_context.Sphere, "Id", "Name", power.SphereId);
            return View(power);
        }

        // POST: Poderes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name,SphereId")] Power power)
        {
            if (id != power.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(power);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerExists(power.Id))
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
            ViewData["SphereId"] = new SelectList(_context.Sphere, "Id", "Name", power.SphereId);
            return View(power);
        }

        // GET: Poderes/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _context.Power.FindAsync(id);
            _context.Power.Remove(power);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerExists(uint id)
        {
            return _context.Power.Any(e => e.Id == id);
        }
    }
}
