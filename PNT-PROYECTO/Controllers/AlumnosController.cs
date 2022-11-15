using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;

namespace PNT_PROYECTO.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        public AlumnosController(PNT_PROYECTOContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        [Authorize(Roles = "ADMIN,ADJUNTO,ATPJTP")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumno.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumno == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (alumno == null)
            {
                return NotFound();
            }

            if (User.FindFirstValue(ClaimTypes.Name).Equals(alumno.Mail) || !User.FindFirstValue(ClaimTypes.Role).Equals("ALUMNO"))
            {
                return View(alumno);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Alumnos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Alumnos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Legajo,NombreApellido,Mail")] Alumno alumno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(alumno);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(alumno);
        //}

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumno == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            if (User.FindFirstValue(ClaimTypes.Name).Equals(alumno.Mail) || User.FindFirstValue(ClaimTypes.Role).Equals("ADMIN"))
            {
                return View(alumno);
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Legajo,NombreApellido,Mail")] Alumno alumno)
        {
            if (id != alumno.Legajo)
            {
                return NotFound();
            }

            if (User.FindFirstValue(ClaimTypes.Name).Equals(alumno.Mail) || User.FindFirstValue(ClaimTypes.Role).Equals("ADMIN"))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(alumno);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AlumnoExists(alumno.Legajo))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View(alumno);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Alumnos/Delete/5
        [Authorize(Roles = "ADMIN,ADJUNTO")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumno == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN,ADJUNTO")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumno == null)
            {
                return Problem("Entity set 'PNT_PROYECTOContext.Alumno'  is null.");
            }
            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumno.Remove(alumno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumno.Any(e => e.Legajo == id);
        }
    }
}
