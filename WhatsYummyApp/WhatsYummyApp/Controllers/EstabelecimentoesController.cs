using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhatsYummyApp.Models;

namespace WhatsYummyApp.Controllers
{
    public class EstabelecimentoesController : Controller
    {
        private readonly WhatsYummyAppContext _context;

        public EstabelecimentoesController(WhatsYummyAppContext context)
        {
            _context = context;  
        }

        // GET: Estabelecimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estabelecimento.ToListAsync());
        }

        // GET: Estabelecimentoes/Details/5
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

        // GET: Estabelecimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Nome,Localidade,CodigoPostal,Rua,Proprietario,Estado")] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        // GET: Estabelecimentoes/Edit/5
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

        // POST: Estabelecimentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Nome,Localidade,CodigoPostal,Rua,Proprietario,Estado")] Estabelecimento estabelecimento)
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

        // GET: Estabelecimentoes/Delete/5
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

        // POST: Estabelecimentoes/Delete/5
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
