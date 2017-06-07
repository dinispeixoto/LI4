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
    public class UtilizadorProdutosController : Controller
    {
        private readonly WhatsYummyContext _context;

        public UtilizadorProdutosController(WhatsYummyContext context)
        {
            _context = context;    
        }

        // GET: UtilizadorProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.UtilizadorProduto.ToListAsync());
        }

        // GET: UtilizadorProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadorProduto = await _context.UtilizadorProduto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (utilizadorProduto == null)
            {
                return NotFound();
            }

            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UtilizadorProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Favorito")] UtilizadorProduto utilizadorProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizadorProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadorProduto = await _context.UtilizadorProduto.SingleOrDefaultAsync(m => m.Id == id);
            if (utilizadorProduto == null)
            {
                return NotFound();
            }
            return View(utilizadorProduto);
        }

        // POST: UtilizadorProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Favorito")] UtilizadorProduto utilizadorProduto)
        {
            if (id != utilizadorProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizadorProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorProdutoExists(utilizadorProduto.Id))
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
            return View(utilizadorProduto);
        }

        // GET: UtilizadorProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadorProduto = await _context.UtilizadorProduto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (utilizadorProduto == null)
            {
                return NotFound();
            }

            return View(utilizadorProduto);
        }

        // POST: UtilizadorProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizadorProduto = await _context.UtilizadorProduto.SingleOrDefaultAsync(m => m.Id == id);
            _context.UtilizadorProduto.Remove(utilizadorProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UtilizadorProdutoExists(int id)
        {
            return _context.UtilizadorProduto.Any(e => e.Id == id);
        }
    }
}
