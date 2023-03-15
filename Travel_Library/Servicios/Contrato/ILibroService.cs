using Travel_Library.Models;

namespace Travel_Library.Servicios.Contrato
{
    //Se definen los Metodos CRUD para el modelo Libro
    public interface ILibroService
    {
        IEnumerable<Libro> GetAllLibros();

        Libro GetLibroDetalle(int id);

        bool InsertLibro(Libro libro);

        bool UpdateLibro(Libro libro);

        bool DeleteLibro(Libro libro);
    }
}
