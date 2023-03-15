using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;
using Travel_Library.Servicios.Implementacion;

namespace Travel_Library.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService= autorService;
        }
        public IActionResult Index()
        {
            //obtener la lista de los libros regstrados en la BD
            IEnumerable<Autor> listaAutores = _autorService.GetAllAutores();

            return View(listaAutores);
        }

        //Metodo para obtener el detalle de un autor basado en su ID
        public IActionResult AutorDetalle(int id)
        {
            Autor autor = BuscarAutor(id);
            return View(autor);
        }

        public IActionResult CrearAutor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearAutor(Autor autor)
        {
            _autorService.InsertAutor(autor);
            return RedirectToAction("Index", "Autor");
        }

        public IActionResult EditarAutor(int id)
        {
            Autor autor = BuscarAutor(id);
            return View(autor);
        }

        [HttpPost]
        public IActionResult EditarAutor(Autor autor)
        {
            _autorService.UpdateAutor(autor);
            return RedirectToAction("Index", "Autor");
        }

        public IActionResult EliminarAutor(int id)
        {
            Autor autor = BuscarAutor(id);
            return View(autor);
        }

        [HttpPost]
        public IActionResult EliminarAutor(Autor autor)
        {
            Autor autorDelete = BuscarAutor(autor.Id);
            _autorService.DeleteAutor(autorDelete);
            return RedirectToAction("Index", "Autor");
        }

        public Autor BuscarAutor(int id)
        {
            Autor autor = new Autor();
            if (id > 0)
            {
                autor = _autorService.GetAutorDetalle(id);
            }
            return autor;
        }
    }
}
