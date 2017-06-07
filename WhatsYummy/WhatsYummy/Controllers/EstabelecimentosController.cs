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
    public class EstabelecimentosController : Controller
    {
        private readonly WhatsYummyContext _context;

        public EstabelecimentosController(WhatsYummyContext context)
        {
            _context = context;    
        }

        // GET: Estabelecimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estabelecimento.ToListAsync());
        }

        // GET: Estabelecimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimento
                .SingleOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Nome,Localidade,CodigoPostal,Rua,Estado,NumProdutos")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                estabelecimento.NumProdutos = 0;

                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimento.SingleOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Nome,Localidade,CodigoPostal,Rua,Estado,NumProdutos")] Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstabelecimentoExists(estabelecimento.Id))
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
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimento
                .SingleOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estabelecimento = await _context.Estabelecimento.SingleOrDefaultAsync(m => m.Id == id);
            _context.Estabelecimento.Remove(estabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EstabelecimentoExists(int id)
        {
            return _context.Estabelecimento.Any(e => e.Id == id);
        }
    }
}
