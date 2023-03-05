using BienesRaices.AccesoDatos.IRepositorio;
using BienesRaices.Models;
using Microsoft.AspNetCore.Mvc;

namespace BienesRaices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VendedoresController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;

        public VendedoresController(IUnidadTrabajo unidadTrabajo)
        {
            this.unidadTrabajo = unidadTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                unidadTrabajo.Vendedor.Add(vendedor);
                unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var VendedorDb = unidadTrabajo.Vendedor.Obtener(id.GetValueOrDefault());

            if (id is null || id == 0)
            {
                return NotFound();
            }
            else if (VendedorDb is null)
            {
                return NotFound();
            }

            return View(VendedorDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                unidadTrabajo.Vendedor.Actualizar(vendedor);
                unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            return View(vendedor);
        }

        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = unidadTrabajo.Vendedor.ObtenerTodo();
            return Json(new {data = todos});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var vendedorDb = unidadTrabajo.Vendedor.Obtener(id.GetValueOrDefault());

            if (id is null || id == 0)
            {
                return Json(new {success = false, message = "Error al eliminar el vendedor"});
            }
            else
            {
                unidadTrabajo.Vendedor.Remover(vendedorDb);
                unidadTrabajo.Guardar();
                return Json(new { success = true, message = "Vendedor Eliminado Correctamente"});
            }
        }
        #endregion
    }
}
