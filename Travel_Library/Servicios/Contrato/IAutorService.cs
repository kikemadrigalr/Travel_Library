using Travel_Library.Models;

namespace Travel_Library.Servicios.Contrato
{
    //Se definen los Metodos CRUD para el modelo Autor
    public interface IAutorService
    {
        IEnumerable<Autor> GetAllAutores();

        Autor GetAutorDetalle(int id);

        bool InsertAutor(Autor autor);

        bool UpdateAutor(Autor autor);

        bool DeleteAutor(Autor autor);
    }
}
