using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;

namespace PNT_PROYECTO.Controllers
{
    public class ProfesARegistrarController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        public ProfesARegistrarController(PNT_PROYECTOContext context)
        {
            _context = context;
        }

        // GET: ProfesARegistrar
        [Authorize(Roles ="ADMIN")]        
        public async Task<IActionResult> Index()
        {
              return View(await _context.profeARegistrar.ToListAsync());
        }

        // GET: ProfesARegistrar/Details/5
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Aceptar(int? id)
        {
            if (id == null || _context.profeARegistrar == null)
            {
                return NotFound();
            }

            var profeARegistrar = await _context.profeARegistrar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profeARegistrar == null)
            {
                return NotFound();
            }

            Profesor p = new Profesor(); 
            p.Descripcion = profeARegistrar.Descripcion;
            p.FechaInicio = profeARegistrar.FechaInicio;
            p.Mail = profeARegistrar.Mail;
            p.NombreApellido = profeARegistrar.NombreApellido;
            p.Password = profeARegistrar.Password;
            p.Tipo = profeARegistrar.Tipo;
            
            _context.Profesor.Add(p);
            _context.profeARegistrar.Remove(profeARegistrar);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: ProfesARegistrar/Delete/5
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.profeARegistrar == null)
            {
                return NotFound();
            }

            var profeARegistrar = await _context.profeARegistrar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profeARegistrar == null)
            {
                return NotFound();
            }

            return View(profeARegistrar);
        }

        // POST: ProfesARegistrar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.profeARegistrar == null)
            {
                return Problem("Entity set 'PNT_PROYECTOContext.profeARegistrar'  is null.");
            }
            var profeARegistrar = await _context.profeARegistrar.FindAsync(id);
            if (profeARegistrar != null)
            {
                _context.profeARegistrar.Remove(profeARegistrar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfeARegistrarExists(int id)
        {
          return _context.profeARegistrar.Any(e => e.Id == id);
        }
    }
}
