using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivrariaAnnaMVC.Data;
using LivrariaAnnaMVC.Models;

namespace LivrariaAnnaMVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly RelacaoLivrosDBContext _context;

        public AuthorController(RelacaoLivrosDBContext context)
        {
            _context = context;
        }

        // GET: Author
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'RelacaoLivrosDBContext.Authors'  is null.");
        }

        // GET: Author/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorModel = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorModel == null)
            {
                return NotFound();
            }

            return View(authorModel);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,AuthorLastName,Email,Birth")] AuthorModel authorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorModel);
        }

        // GET: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorModel = await _context.Authors.FindAsync(id);
            if (authorModel == null)
            {
                return NotFound();
            }
            return View(authorModel);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,AuthorLastName,Email,Birth")] AuthorModel authorModel)
        {
            if (id != authorModel.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorModelExists(authorModel.AuthorId))
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
            return View(authorModel);
        }

        // GET: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorModel = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorModel == null)
            {
                return NotFound();
            }

            return View(authorModel);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'RelacaoLivrosDBContext.Authors'  is null.");
            }
            var authorModel = await _context.Authors.FindAsync(id);
            if (authorModel != null)
            {
                _context.Authors.Remove(authorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorModelExists(int id)
        {
          return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
