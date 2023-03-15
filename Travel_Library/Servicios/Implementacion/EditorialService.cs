using Travel_Library.Data;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Travel_Library.Servicios.Implementacion
{
    public class EditorialService : IEditorialService
    {
        private readonly TravelLibraryContext _context;

        public EditorialService(TravelLibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Editorial> GetAllEditoriales()
        {
            return _context.Editorials.ToList();
        }

        public Editorial GetEditorialDetalle(int id)
        {
            var editorial = _context.Editorials.Find(id);
            return editorial;
        }

        public bool InsertEditorial(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateEditorial(Editorial editorial)
        {
            _context.Entry(editorial).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteEditorial(Editorial editorial)
        {
            _context.Editorials.Remove(editorial);
            var result  = _context.SaveChanges();
            return result > 0;
        }
    }
}
