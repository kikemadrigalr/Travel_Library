using Travel_Library.Data;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Travel_Library.Servicios.Implementacion
{
    public class AutorService : IAutorService
    {
        //conexion a la base de datos en el constructor de la clase AutorServices
        public readonly TravelLibraryContext _context;

        public AutorService(TravelLibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Autor> GetAllAutores()
        {
            return _context.Autors.ToList();
        }

        public Autor GetAutorDetalle(int id)
        {
            var autor = _context.Autors.Find(id);
            return autor;
        }

        public bool InsertAutor(Autor autor)
        {
            _context.Autors.Add(autor);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateAutor(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteAutor(Autor autor)
        {
            _context.Autors.Remove(autor);
            var result = _context.SaveChanges();
            return result > 0;
        }

        
    }
}
