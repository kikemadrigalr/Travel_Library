using Travel_Library.Models;

namespace Travel_Library.Servicios.Contrato
{
    //Se definen los Metodos CRUD para el modelo Editorial
    public interface IEditorialService
    {
        IEnumerable<Editorial> GetAllEditoriales();

        Editorial GetEditorialDetalle(int id);

        bool InsertEditorial(Editorial editorial);

        bool UpdateEditorial(Editorial editorial);

        bool DeleteEditorial(Editorial editorial);
    }
}
