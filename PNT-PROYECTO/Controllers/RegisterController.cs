using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;

namespace PNT_PROYECTO.Controllers
{
    public class RegisterController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        public RegisterController(PNT_PROYECTOContext context)
        {
            _context = context;
        }

        // GET: Profesores/Create
        public IActionResult RegistrarProfesor()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarProfesor(Profesor profesor)
        {
            if (ModelState.IsValid)
            {

                var listaPersonas = _context.Persona.Where(o => o.Mail == profesor.Mail).ToList();
                if (listaPersonas.Count == 0)
                {

                    _context.Add(profesor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index","Login");
                }
                else {
                    ViewBag.mensajeError = "Mail ya registrado";
                }
                    
            }
            return View(profesor);
        }



        // GET: Profesores/Create
        public IActionResult RegistrarAlumno()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarAlumno(Alumno alumno)
        {
            if (ModelState.IsValid)
            {

                var listaPersonas = _context.Persona.Where(o => o.Mail == alumno.Mail).ToList();
                if (listaPersonas.Count == 0)
                {

                    _context.Add(alumno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Login");
                }
                
                else
                {
                    ViewBag.mensajeError = "Mail ya registrado";
                }

            }
            return View(alumno);
        }
    }
}
