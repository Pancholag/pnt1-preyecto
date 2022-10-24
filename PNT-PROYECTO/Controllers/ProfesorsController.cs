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
    public class ProfesorsController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        public ProfesorsController(PNT_PROYECTOContext context)
        {
            _context = context;
        }

        // GET: Profesors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Profesor.ToListAsync());
        }

        // GET: Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaInicio,Descripcion,Tipo,Legajo,Nombre,Apellido,Mail")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        // GET: Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaInicio,Descripcion,Tipo,Legajo,Nombre,Apellido,Mail")] Profesor profesor)
        {
            if (id != profesor.Legajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Legajo))
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
            return View(profesor);
        }

        // GET: Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesor == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesor
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesor == null)
            {
                return Problem("Entity set 'PNT_PROYECTOContext.Profesor'  is null.");
            }
            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesor.Remove(profesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
          return _context.Profesor.Any(e => e.Legajo == id);
        }
    }
}
