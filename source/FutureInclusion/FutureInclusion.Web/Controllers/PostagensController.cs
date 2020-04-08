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
    public class PostagensController : Controller
    {
        private readonly MySQLContext _context;

        public PostagensController(MySQLContext context)
        {
            _context = context;
        }

        // GET: Postagens
        public async Task<IActionResult> Index()
        {
            var mySQLContext = _context.Post.Include(p => p.Mandate).Include(p => p.Poll);
            return View(await mySQLContext.ToListAsync());
        }

        // GET: Postagens/Create
        public IActionResult Create()
        {
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title");
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description");
            return View();
        }

        // POST: Postagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,Date,PollId,MandateId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", post.MandateId);
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", post.PollId);
            return View(post);
        }

        // GET: Postagens/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", post.MandateId);
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", post.PollId);
            return View(post);
        }

        // POST: Postagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Text,Date,PollId,MandateId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["MandateId"] = new SelectList(_context.Mandate, "Id", "Title", post.MandateId);
            ViewData["PollId"] = new SelectList(_context.Poll, "Id", "Description", post.PollId);
            return View(post);
        }

        // GET: Postagens/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(uint id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
