using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PNT_PROYECTO.Data;
using PNT_PROYECTO.Models;
using System.Security.Claims;

namespace Stock.Controllers
{
    public class LoginController : Controller
    {
        private readonly PNT_PROYECTOContext _context;

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
        public IActionResult Index(LoginViewModel usuario)
        {

            var listaPersonas = _context.Persona.Where(o => o.Mail == usuario.Mail &&
            o.Password == usuario.Password).ToList();

            if (listaPersonas.Count > 0) 
            {
                Persona p = listaPersonas[0];


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

                    switch (profe.Tipo) 
                    {
                        case Profesor.Rol.TITULAR: {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));
                                break;
                            }
                        case Profesor.Rol.ADJUNTO:
                            {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ADJUNTO"));
                                break;
                            }
                        default: {
                                identity.AddClaim(new Claim(ClaimTypes.Role, "ATPJTP"));
                                break;
                            }
                    }
                }
                else
                    identity.AddClaim(new Claim(ClaimTypes.Role, "ALUMNO"));

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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return View("Index");
        }
    }
}
