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
    public class MandatosController : Controller
    {
        private readonly MySQLContext _context;

        public MandatosController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Mandatos
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.Mandate.Include(m => m.City).Include(m => m.Country).Include(m => m.Power).Include(m => m.State);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Mandatos/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["PowerId"] = new SelectList(_context.Power, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name");
            return View();
        }

        // POST: Mandatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Title,Active,Validated,ValidatedDate,PowerId,CityId,StateId,CountryId")] Mandate mandate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mandate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", mandate.CityId);
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", mandate.CountryId);
            ViewData["PowerId"] = new SelectList(_context.Power, "Id", "Name", mandate.PowerId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", mandate.StateId);
            return View(mandate);
        }

        // GET: Mandatos/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mandate = await _context.Mandate.FindAsync(id);
            if (mandate == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", mandate.CityId);
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", mandate.CountryId);
            ViewData["PowerId"] = new SelectList(_context.Power, "Id", "Name", mandate.PowerId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", mandate.StateId);
            return View(mandate);
        }

        // POST: Mandatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,StartDate,EndDate,Title,Active,Validated,ValidatedDate,PowerId,CityId,StateId,CountryId")] Mandate mandate)
        {
            if (id != mandate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mandate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MandateExists(mandate.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", mandate.CityId);
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", mandate.CountryId);
            ViewData["PowerId"] = new SelectList(_context.Power, "Id", "Name", mandate.PowerId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Name", mandate.StateId);
            return View(mandate);
        }

        // GET: Mandatos/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mandate = await _context.Mandate.FindAsync(id);
            _context.Mandate.Remove(mandate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MandateExists(uint id)
        {
            return _context.Mandate.Any(e => e.Id == id);
        }
    }
}
