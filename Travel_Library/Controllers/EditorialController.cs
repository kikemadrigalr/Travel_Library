using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;
using Travel_Library.Servicios.Implementacion;

namespace Travel_Library.Controllers
{
    [Authorize]
    public class EditorialController : Controller
    {
        private readonly IEditorialService _editorialService;
        
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        public IActionResult Index()
        {
            IEnumerable<Editorial> listaEditoriales = _editorialService.GetAllEditoriales();
            return View(listaEditoriales);
        }

        public IActionResult EditorialDetalle(int id)
        {
            Editorial editorial = BuscarEditorial(id);
            return View(editorial);
        }

        public IActionResult CrearEditorial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearEditorial(Editorial editorial)
        {
            _editorialService.InsertEditorial(editorial);
            return RedirectToAction("Index", "Editorial");
        }

        public IActionResult EditarEditorial(int id)
        {
            Editorial editorial = BuscarEditorial(id);
            return View(editorial); ;
        }

        [HttpPost]
        public IActionResult EditarEditorial(Editorial editorial)
        {
            _editorialService.UpdateEditorial(editorial);
            return RedirectToAction("Index", "Editorial");
        }

        public IActionResult EliminarEditorial(int id)
        {
            Editorial editorial = BuscarEditorial(id);
            return View(editorial);
        }

        [HttpPost]
        public IActionResult EliminarEditorial(Editorial editorial)
        {
            Editorial editorialDelete = BuscarEditorial(editorial.Id);
            _editorialService.DeleteEditorial(editorialDelete);
            return RedirectToAction("Index", "Editorial");
        }

        public Editorial BuscarEditorial(int id)
        {
            Editorial editorial = new Editorial();
            if (id > 0)
            {
                editorial = _editorialService.GetEditorialDetalle(id);
            }
            return editorial;
        }
    }
}
