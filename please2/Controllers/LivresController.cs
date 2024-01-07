using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using please2.Data;
using please2.Models;
using static please2.Models.paginatedList;

namespace please2.Controllers
{
    public class LivresController : Controller
    {
        private readonly ApplicationDbContext _context;


        public LivresController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        // GET: Livres
        public async Task<IActionResult> Index(string cat,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)

        

        {  ViewData["CurrentFilter"] = searchString;
            ViewData["cat"] = cat;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var livres = from livre in _context.Livre
                         join category in _context.Category
                         on livre.category.Id equals category.Id
                         join author in _context.Author on livre.author.Id equals author.Id
                         select new Livre1
                         {   Id= livre.Id,
                             title = livre.title,
                             category = category.Name,
                             price=livre.price,
                             author=author.Name,
                             description=livre.description,
                             edition=livre.edition,
                             distribution=livre.distribution,
                             img=livre.img,
                         };
          
            if (!String.IsNullOrEmpty(searchString))
            {
                livres = livres.Where(s => s.author.Contains(searchString)
                                       || s.title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(cat))
            {
                livres = livres.Where(s => s.category.Contains(cat));
            }
            int pageSize = 6;
            return  
                          View(await PaginatedList<Livre1>.CreateAsync(livres.AsNoTracking(), pageNumber ?? 1, pageSize));
            
        }

        // GET: Livres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }
           

            return View(livre);
        }

        // GET: Livres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,price,author,edition,distribution")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livre);
        }

        // GET: Livres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            return View(livre);
        }

        // POST: Livres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,price,author,edition,distribution")] Livre livre)
        {
            if (id != livre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.Id))
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
            return View(livre);
        }

        // GET: Livres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livre == null)
            {
                return Problem("Entity set 'please2Context.Livre'  is null.");
            }
            var livre = await _context.Livre.FindAsync(id);
            if (livre != null)
            {
                _context.Livre.Remove(livre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(int id)
        {
          return (_context.Livre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
