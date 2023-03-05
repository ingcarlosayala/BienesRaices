using BienesRaices.AccesoDatos.IRepositorio;
using BienesRaices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BienesRaices.Areas.BienesRaices.Controllers
{
    [Area("BienesRaices")]
    public class HomeController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public HomeController(IUnidadTrabajo unidadTrabajo)
        {
            this.unidadTrabajo = unidadTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var propiedadDb = unidadTrabajo.Propiedade.ObtenerTodo(incluirPropiedades: "Vendedor").Take(3);

            return View(propiedadDb);
        }

        [HttpGet]
        public IActionResult Anuncios()
        {
            var propiedadDb = unidadTrabajo.Propiedade.ObtenerTodo(incluirPropiedades: "Vendedor");

            return View(propiedadDb);
        }

        [HttpGet]
        public IActionResult Nosotros()
        {
            var propiedadDb = unidadTrabajo.Propiedade.ObtenerTodo(incluirPropiedades: "Vendedor");

            return View(propiedadDb);
        }

        [HttpGet]
        public IActionResult Detalles(int? id)
        {
            var propiedadDb = unidadTrabajo.Propiedade.ObtenerPrimero(p => p.Id == id.GetValueOrDefault());

            if (id is null || id == 0)
            {
                return NotFound();
            }

            if (propiedadDb is null)
            {
                return NotFound();
            }

            return View(propiedadDb);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}