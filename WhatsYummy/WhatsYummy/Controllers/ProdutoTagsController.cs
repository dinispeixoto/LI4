using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatsYummy.Models;

namespace WhatsYummy.Controllers
{
    public class ProdutoTagsController : Controller
    {
        private readonly WhatsYummyContext _context;

        public ProdutoTagsController(WhatsYummyContext context)
        {
            _context = context;    
        }

        // GET: ProdutoTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdutoTag.ToListAsync());
        }

        // GET: ProdutoTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoTag = await _context.ProdutoTag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (produtoTag == null)
            {
                return NotFound();
            }

            return View(produtoTag);
        }

        // GET: ProdutoTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ProdutoTag produtoTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoTag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(produtoTag);
        }

        // GET: ProdutoTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoTag = await _context.ProdutoTag.SingleOrDefaultAsync(m => m.Id == id);
            if (produtoTag == null)
            {
                return NotFound();
            }
            return View(produtoTag);
        }

        // POST: ProdutoTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ProdutoTag produtoTag)
        {
            if (id != produtoTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoTagExists(produtoTag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(produtoTag);
        }

        // GET: ProdutoTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoTag = await _context.ProdutoTag
                .SingleOrDefaultAsync(m => m.Id == id);
            if (produtoTag == null)
            {
                return NotFound();
            }

            return View(produtoTag);
        }

        // POST: ProdutoTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoTag = await _context.ProdutoTag.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProdutoTag.Remove(produtoTag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProdutoTagExists(int id)
        {
            return _context.ProdutoTag.Any(e => e.Id == id);
        }
    }
}
