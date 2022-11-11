using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;
using SQLitePCL;

namespace PNT_PROYECTO.Controllers
{
    public class ExamenesController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        public ExamenesController(PNT_PROYECTOContext context)
        {
            _context = context;
        }

        // GET: Examenes
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.Examen.Include(j => j.Profe);
            return View(await stockContext.ToListAsync());
        }

        // GET: Examenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Examen == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examen == null)
            {
                return NotFound();
            }
            examen.Profe = await _context.Profesor.FirstOrDefaultAsync(p => examen.ProfeId == p.Legajo);

            /*
             necesitamos que "examen.Materiales" tenga un valor, pero en la bd tenemos una tabla intermedia
             */

            //var materiales = _context.ExamenMaterial.Where(p => examen.Id == p.ExamenId).ToList();

            examen.Materiales = null;

            return View(examen);
        }

        // GET: Examenes/Create
        public IActionResult Create()
        {
            ViewData["Legajo"] = new SelectList(_context.Profesor, "Legajo", "NombreApellido");
            ExamenViewModel modelo = new ExamenViewModel(); 
            modelo.Materiales = new SelectList(_context.Material, "Id", "Titulo");
            return View(modelo);
        }

        // POST: Examenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamenViewModel examenVM)
        {
            Examen examen = new Examen();
            if (ModelState.IsValid)
            {
                
                examen.Fecha = examenVM.Fecha;
                examen.Titulo = examenVM.Titulo;
                examen.ProfeId = examenVM.ProfeId;
                
                ICollection<Material> matAux = new List<Material>();

                foreach (Int32 materialId in examenVM.MaterialesSeleccionados) {
                    matAux.Add(await _context.Material.FindAsync(materialId));
                }
                
                examen.Materiales = matAux;

                _context.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Legajo"] = new SelectList(_context.Profesor, "Legajo", "NombreApellido", examen.ProfeId);
            return View(examenVM);
        }

        // GET: Examenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Examen == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen.FindAsync(id);
            if (examen == null)
            {
                return NotFound();
            }

            ViewData["Legajo"] = new SelectList(_context.Profesor, "Legajo", "NombreApellido", examen.ProfeId);

            return View(examen);
        }

        // POST: Examenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Examen examen)
        {
            if (id != examen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamenExists(examen.Id))
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
            ViewData["Legajo"] = new SelectList(_context.Profesor, "Legajo", "Legajo", examen.ProfeId);
            return View(examen);
        }

        // GET: Examenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Examen == null)
            {
                return NotFound();
            }

            var examen = await _context.Examen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examen == null)
            {
                return NotFound();
            }

            return View(examen);
        }

        // POST: Examenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Examen == null)
            {
                return Problem("Entity set 'PNT_PROYECTOContext.Examen'  is null.");
            }
            var examen = await _context.Examen.FindAsync(id);
            if (examen != null)
            {
                _context.Examen.Remove(examen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamenExists(int id)
        {
          return _context.Examen.Any(e => e.Id == id);
        }
    }
}
