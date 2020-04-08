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
    public class CidadesController : Controller
    {
        private readonly MySQLContext _context;

        public CidadesController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.City.Include(c => c.State);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", city.StateId);
            return View(city);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name,StateId")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", city.StateId);
            return View(city);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(uint id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}
