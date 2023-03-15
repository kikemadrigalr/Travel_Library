using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Travel_Library.Data;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;

namespace Travel_Library.Servicios.Implementacion
{
    public class LibroService : ILibroService
    {
        //conexion a la base de datos en el constructor de la clase LibroServices
        public readonly TravelLibraryContext _context;

        public LibroService(TravelLibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Libro> GetAllLibros()
        {
            return _context.Libros.ToList();
        }

        public Libro GetLibroDetalle(int id)
        {
            var libro = _context.Libros.Find(id);
            return libro;
        }

        public bool InsertLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateLibro(Libro libro)
        {
            //_context.Libros.Update(libro);
            _context.Entry(libro).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteLibro(Libro libro)
        {
            //_context.Libros.Find(libro.Isbn);
            _context.Libros.Remove(libro);
            var result = _context.SaveChanges();

            return result > 0;
        }
    }
}
