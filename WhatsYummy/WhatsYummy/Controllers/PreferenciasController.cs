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
    public class PreferenciasController : Controller
    {
        private readonly WhatsYummyContext _context;

        public PreferenciasController(WhatsYummyContext context)
        {
            _context = context;    
        }

        // GET: Preferencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Preferencia.ToListAsync());
        }

        // GET: Preferencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencia
                .SingleOrDefaultAsync(m => m.Id == id);
            if (preferencia == null)
            {
                return NotFound();
            }

            return View(preferencia);
        }

        // GET: Preferencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Preferencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Preferencia preferencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preferencia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(preferencia);
        }

        // GET: Preferencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencia.SingleOrDefaultAsync(m => m.Id == id);
            if (preferencia == null)
            {
                return NotFound();
            }
            return View(preferencia);
        }

        // POST: Preferencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Preferencia preferencia)
        {
            if (id != preferencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreferenciaExists(preferencia.Id))
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
            return View(preferencia);
        }

        // GET: Preferencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preferencia = await _context.Preferencia
                .SingleOrDefaultAsync(m => m.Id == id);
            if (preferencia == null)
            {
                return NotFound();
            }

            return View(preferencia);
        }

        // POST: Preferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preferencia = await _context.Preferencia.SingleOrDefaultAsync(m => m.Id == id);
            _context.Preferencia.Remove(preferencia);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PreferenciaExists(int id)
        {
            return _context.Preferencia.Any(e => e.Id == id);
        }
    }
}
