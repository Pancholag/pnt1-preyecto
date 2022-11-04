using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;

namespace PNT_PROYECTO.Controllers
{
    public class MaterialesController : Controller
    {
        private readonly PNT_PROYECTOContext _stockContext;

        public MaterialesController(PNT_PROYECTOContext context)
        {
            _stockContext = context;
        }

        // GET: Materiales
        public async Task<IActionResult> Index()
        {
            var stockContext = _stockContext.Material.Include(j => j.Profe);
            return View(await stockContext.ToListAsync());
        }

        // GET: Materiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _stockContext.Material == null)
            {
                return NotFound();
            }

            var material = await _stockContext.Material
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiales/Create
        public IActionResult Create()
        {
            ViewData["Legajo"] = new SelectList(_stockContext.Profesor, "Legajo", "NombreApellido");
            return View();
        }

        // POST: Materiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Material material)
        {
            if (ModelState.IsValid)
            {
                _stockContext.Add(material);
                await _stockContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Legajo"] = new SelectList(_stockContext.Profesor, "Legajo", "NombreApellido", material.ProfeId);
            return View(material);
        }

        // GET: Materiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _stockContext.Material == null)
            {
                return NotFound();
            }

            var material = await _stockContext.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["Legajo"] = new SelectList(_stockContext.Profesor, "Legajo", "NombreApellido", material.ProfeId);
            return View(material);
        }

        // POST: Materiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _stockContext.Update(material);
                    await _stockContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            ViewData["Legajo"] = new SelectList(_stockContext.Profesor, "Legajo", "Legajo", material.ProfeId);
            return View(material);
        }

        // GET: Materiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _stockContext.Material == null)
            {
                return NotFound();
            }

            var material = await _stockContext.Material
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_stockContext.Material == null)
            {
                return Problem("Entity set 'PNT_PROYECTOContext.Material'  is null.");
            }
            var material = await _stockContext.Material.FindAsync(id);
            if (material != null)
            {
                _stockContext.Material.Remove(material);
            }
            
            await _stockContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
          return _stockContext.Material.Any(e => e.Id == id);
        }
    }
}
