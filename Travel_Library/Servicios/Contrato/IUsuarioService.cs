using Microsoft.EntityFrameworkCore;
using Travel_Library.Models;

namespace Travel_Library.Servicios.Contrato
{
    //Definicion de la Interfaz que tiene los metodos para el usuario
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string contrasena);
    }
}
