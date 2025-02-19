using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSession.Extensions;
using MvcNetCoreSession.Models;

namespace MvcNetCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {

        HelperSessionContextAccessor helper;

        public EjemploSessionController(HelperSessionContextAccessor helper)
        {
            this.helper = helper;
        }
        public IActionResult Index()
        {
            List<Mascota> mascotas = helper.GetMascotasSession();
            return View(mascotas);
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota { 
                        Nombre = "Firulais",
                        Raza = "Pastor Alemán",
                        Edad = 3,
                    };
                    SessionExtension.SetObject(HttpContext.Session, "mascota", mascota);
                    ViewData["MENSAJE"] = "Datos almacenados en la sesión";
                }
                if (accion.ToLower() == "mostrar")
                {
                    string datos = HttpContext.Session.GetString("mascota");
                    Mascota mascota = SessionExtension.GetObject<Mascota>(HttpContext.Session, "mascota");
                    ViewData["NOMBRE"] = mascota.Nombre;
                    ViewData["RAZA"] = mascota.Raza;
                    ViewData["EDAD"] = mascota.Edad;
                }
            }
            return View();
        }

        public IActionResult SessionMascotasList(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>();
                    mascotas.Add(new Mascota { Nombre = "Firulais", Raza = "Pastor Alemán", Edad = 3 });
                    mascotas.Add(new Mascota { Nombre = "Rex", Raza = "Bulldog", Edad = 2 });
                    mascotas.Add(new Mascota { Nombre = "Toby", Raza = "Poodle", Edad = 1 });
                    SessionExtension.SetObject(HttpContext.Session, "mascotas", mascotas);
                    ViewData["MENSAJE"] = "Datos almacenados en la sesión";
                }
                if (accion.ToLower() == "mostrar")
                {
                    string datos = HttpContext.Session.GetString("mascotas");
                    List<Mascota> mascotas = SessionExtension.GetObject<List<Mascota>>(HttpContext.Session, "mascotas");
                    ViewData["Mascotas"] = mascotas;
                }
            }
            return View();
        }

        public IActionResult SessionSimple(string accion)
        {
            if(accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("nombre", "Víctor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToString());
                    ViewData["MENSAJE"] = "Datos almacenados en la sesión";
                }
                if(accion.ToLower() == "mostrar")
                {
                    ViewData["NOMBRE"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }
    }
}
