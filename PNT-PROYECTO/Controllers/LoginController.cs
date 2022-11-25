using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;
using System.Security.Claims;

namespace Stock.Controllers
{
    public class LoginController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

        private static int cantIngresosProfesor = 0;
        private static int cantIngresosAlumno = 0;



        public LoginController(PNT_PROYECTOContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            string nombre = User.FindFirstValue(ClaimTypes.Name);
            if (nombre == null)
            {

            }
            else
            {
                ViewBag.NombreUsuario = nombre;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(LoginViewModel usuario)
        {

            var listaPersonas = _context.Persona.Where(o => o.Mail == usuario.Mail &&
            o.Password == usuario.Password).ToList();

            if (listaPersonas.Count > 0) 
            {
                Persona p = listaPersonas[0];

                Ingreso ingreso = new Ingreso();
                ingreso.horaIngreso = DateTime.Now;
                ingreso.usuario = p;

                _context.Add(ingreso);
                await _context.SaveChangesAsync();


                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                // El lo que luego obtendré al acceder a User.Identity.Name
                identity.AddClaim(new Claim(ClaimTypes.Name, p.Mail));

                // Se utilizará para la autorización por roles
                //if (usuario.NombreApellido == "Eduardo")
                //    identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));
                //else
                //    identity.AddClaim(new Claim(ClaimTypes.Role, "USUARIO"));


                if (p is Profesor)
                {
                    Profesor profe = (Profesor)p;
                    cantIngresosProfesor++;
                    switch (profe.Tipo)
                    {
                        case Profesor.Rol.TITULAR:
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));
                                break;
                            }
                        case Profesor.Rol.ADJUNTO:
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ADJUNTO"));
                                break;
                            }
                        default:
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ATPJTP"));
                                break;
                            }
                    }
                }
                else {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "ALUMNO"));
                    cantIngresosAlumno++;
                }

                // Lo utilizaremos para acceder al Id del usuario que se encuentra en el sistema.
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, p.Legajo.ToString()));

                // Lo utilizaremos cuando querramos mostrar el nombre del usuario logueado en el sistema.
                identity.AddClaim(new Claim(ClaimTypes.GivenName, p.Mail));

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                // En este paso se hace el login del usuario al sistema
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal).Wait();


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MensajeDeError = "El usuario es incorrecto.";
                return View();
            }
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Estadistica() {
            ViewBag.cantIngresosAlumno = cantIngresosAlumno;
            ViewBag.cantIngresosProfesor = cantIngresosProfesor;
            var context = _context.Ingreso.Include(j => j.usuario);
            return View(await context.ToListAsync());
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
