using Microsoft.EntityFrameworkCore;
using Travel_Library.Data;
using Travel_Library.Models;
using Travel_Library.Servicios.Contrato;

namespace Travel_Library.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        //Accediendo al contexto de la base de datos
        private readonly TravelLibraryContext _context;

        public UsuarioService(TravelLibraryContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string contrasena)
        {
            Usuario usuario_encontrado = await _context.Usuarios.Where(u => u.Correo == correo && u.Contrasena == contrasena)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }
    }
}
