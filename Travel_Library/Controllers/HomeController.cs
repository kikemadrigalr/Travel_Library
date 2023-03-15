using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using Travel_Library.Data;
using Travel_Library.Models;
using Microsoft.EntityFrameworkCore;
using Travel_Library.Servicios.Contrato;


namespace Travel_Library.Controllers
{
    //Controlador Home

    [Authorize] //solo los usuarios autorizados pueden acceder a los metodos del controlador
    public class HomeController : Controller
    {
        //contexto para conectar la base de datos a este modelo
        private readonly ILibroService _libroService;

        public HomeController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUsuario = HttpContext.User;
            string nombreUsuario = "";

            //si el usuario esta autenticado capturar el correo y mostarlo en la vista Index del Home una vez inciado sesion
            if(claimUsuario.Identity.IsAuthenticated)
            {
                nombreUsuario = claimUsuario.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }

            ViewData["Usuario"] = nombreUsuario;

            //obtener la lista de los libros regstrados en la BD
            IEnumerable<Libro> listaLibros = _libroService.GetAllLibros();
            
            return View(listaLibros);
        }

        public IActionResult LibroDetalle(int id) 
        {
            //Libro libro = new Libro();
            //if(id > 0)
            //{
            //    libro = _libroService.GetLibroDetalle(id);
            //}
            Libro libro = BuscarLibro(id);
            return View("LibroDetalle", libro);
        }

        public IActionResult CrearLibro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {
            _libroService.InsertLibro(libro);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditarLibro(int id)
        {
            //Libro libro = new Libro();
            //if (id > 0)
            //{
            //    libro = _libroService.GetLibroDetalle(id);
            //}
            Libro libro = BuscarLibro(id);
            return View(libro);
        }

        [HttpPost]
        public IActionResult EditarLibro(int id, Libro libro)
        {
            libro.Isbn = id;
            _libroService.UpdateLibro(libro);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EliminarLibro(int id)
        {
            Libro libro = BuscarLibro(id);
            return View(libro);
        }

        [HttpPost]
        public IActionResult EliminarLibro(int id, Libro libro)
        {
            libro = BuscarLibro(id);
;           _libroService.DeleteLibro(libro);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            //Eliminar la Autenticacion de usuario al cerrar sesión
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }

        public Libro BuscarLibro(int id)
        {
            Libro libro = new Libro();
            if (id > 0)
            {
                libro = _libroService.GetLibroDetalle(id);
            }
            return libro;
        }
    }
}