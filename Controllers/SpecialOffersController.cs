using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opticron.Data;
using Opticron.Models;

namespace Opticron.Controllers
{
    public class SpecialOffersController : Controller
    {
        private readonly OpticronContext _context;

        public SpecialOffersController(OpticronContext context)
        {
            _context = context;
        }

        // GET: SpecialOffers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialOffers.ToListAsync());
        }

        // GET: SpecialOffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffers = await _context.SpecialOffers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialOffers == null)
            {
                return NotFound();
            }

            return View(specialOffers);
        }

        // GET: SpecialOffers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Description,OfferText,Link")] SpecialOffers specialOffers)
        {
            if (HttpContext.Request?.Form is FormCollection fc && fc.Files.Any())
            {
                var file = fc.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    var content = new byte[stream.Length];
                    stream.Read(content, 0, content.Length);
                    specialOffers.Image = content;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(specialOffers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialOffers);
        }

        // GET: SpecialOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffers = await _context.SpecialOffers.FindAsync(id);
            if (specialOffers == null)
            {
                return NotFound();
            }
            return View(specialOffers);
        }

        // POST: SpecialOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Description,OfferText,Link")] SpecialOffers specialOffers)
        {
            if (id != specialOffers.Id)
            {
                return NotFound();
            }

            if (HttpContext.Request?.Form is FormCollection fc && fc.Files.Any())
            {
                var file = fc.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    var content = new byte[stream.Length];
                    stream.Read(content, 0, content.Length);
                    specialOffers.Image = content;
                }
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialOffers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialOffersExists(specialOffers.Id))
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
            return View(specialOffers);
        }

        // GET: SpecialOffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialOffers = await _context.SpecialOffers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialOffers == null)
            {
                return NotFound();
            }

            return View(specialOffers);
        }

        // POST: SpecialOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialOffers = await _context.SpecialOffers.FindAsync(id);
            if (specialOffers != null)
            {
                _context.SpecialOffers.Remove(specialOffers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialOffersExists(int id)
        {
            return _context.SpecialOffers.Any(e => e.Id == id);
        }
    }
}
