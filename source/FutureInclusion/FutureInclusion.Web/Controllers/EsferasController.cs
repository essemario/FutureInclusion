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
    public class EsferasController : Controller
    {
        private readonly MySQLContext _context;

        public EsferasController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Esferas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sphere.ToListAsync());
        }

        // GET: Esferas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Esferas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Sphere sphere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sphere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sphere);
        }

        // GET: Esferas/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sphere = await _context.Sphere.FindAsync(id);
            if (sphere == null)
            {
                return NotFound();
            }
            return View(sphere);
        }

        // POST: Esferas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name")] Sphere sphere)
        {
            if (id != sphere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sphere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SphereExists(sphere.Id))
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
            return View(sphere);
        }

        // GET: Esferas/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sphere = await _context.Sphere.FindAsync(id);
            _context.Sphere.Remove(sphere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SphereExists(uint id)
        {
            return _context.Sphere.Any(e => e.Id == id);
        }
    }
}
