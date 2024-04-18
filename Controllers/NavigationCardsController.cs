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
    public class NavigationCardsController : Controller
    {
        private readonly OpticronContext _context;

        public NavigationCardsController(OpticronContext context)
        {
            _context = context;
        }

        // GET: NavigationCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.NavigationCards.ToListAsync());
        }

        // GET: NavigationCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationCards = await _context.NavigationCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigationCards == null)
            {
                return NotFound();
            }

            return View(navigationCards);
        }

        // GET: NavigationCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NavigationCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Image, Description,Link,LinkText")] NavigationCards navigationCards)
        {
            if (HttpContext.Request?.Form is FormCollection fc && fc.Files.Any())
{
    var file = fc.Files[0];
    using (var stream = file.OpenReadStream())
    {
        var content = new byte[stream.Length];
        stream.Read(content, 0, content.Length);
        navigationCards.Image = content;
    }
}
            if (ModelState.IsValid)
            {
                _context.Add(navigationCards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(navigationCards);
        }

        // GET: NavigationCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationCards = await _context.NavigationCards.FindAsync(id);
            if (navigationCards == null)
            {
                return NotFound();
            }
            return View(navigationCards);
        }

        // POST: NavigationCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Image, Description,Link,LinkText")] NavigationCards navigationCards)
        {
            if (id != navigationCards.Id)
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
                    navigationCards.Image = content;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navigationCards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavigationCardsExists(navigationCards.Id))
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
            return View(navigationCards);
        }

        // GET: NavigationCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navigationCards = await _context.NavigationCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (navigationCards == null)
            {
                return NotFound();
            }

            return View(navigationCards);
        }

        // POST: NavigationCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var navigationCards = await _context.NavigationCards.FindAsync(id);
            if (navigationCards != null)
            {
                _context.NavigationCards.Remove(navigationCards);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavigationCardsExists(int id)
        {
            return _context.NavigationCards.Any(e => e.Id == id);
        }
    }
}
