using Microsoft.AspNetCore.Mvc;
using Travel_Library.Models;
using Travel_Library.Controllers;
using Travel_Library.Recursos;
using Travel_Library.Servicios.Contrato;

//referencias para autorizacion por cookies
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Travel_Library.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string contrasena)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo, Utilidades.EncriptarPassword(contrasena));

            //si no se encuentra el usuario enviar mensaje de error
            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontró el Usuario";
                return View();
            }

            //si el usuario se encuntra 
            //configurar la autenticacion del usuario

            List<Claim> claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Correo)
            };

            ClaimsIdentity claimsIdentity= new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            //regitrar al usuario como iniciado sesion
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
