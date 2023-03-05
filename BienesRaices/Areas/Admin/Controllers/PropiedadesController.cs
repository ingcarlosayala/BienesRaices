using BienesRaices.AccesoDatos.IRepositorio;
using BienesRaices.Models;
using BienesRaices.Models.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace BienesRaices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropiedadesController : Controller
    {
        private readonly IUnidadTrabajo unidadTrabajo;
        private readonly IWebHostEnvironment hostEnvironment;

        public PropiedadesController(IUnidadTrabajo unidadTrabajo,IWebHostEnvironment hostEnvironment)
        {
            this.unidadTrabajo = unidadTrabajo;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            PropiedadVM propiedadVM = new PropiedadVM()
            {
                Propiedade = new Propiedade(),
                ListaVendedor = unidadTrabajo.Vendedor.ListaVendedor()
            };

            return View(propiedadVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropiedadVM propiedadVM)
        {
            if (ModelState.IsValid)
            {
                string WebRootPath = hostEnvironment.WebRootPath;
                var Files = HttpContext.Request.Form.Files;

                if (propiedadVM.Propiedade.Id == 0)
                {
                    string FilesName = Guid.NewGuid().ToString();
                    var Upload = Path.Combine(WebRootPath, @"imagenes\propiedad");
                    var Extension = Path.GetExtension(Files[0].FileName);

                    using (var filesStrems = new FileStream(Path.Combine(Upload,FilesName + Extension),FileMode.Create))
                    {
                        Files[0].CopyTo(filesStrems);
                    }

                    propiedadVM.Propiedade.FechaCreacion = DateTime.Now.ToString();
                    propiedadVM.Propiedade.ImagenUrl = @"\imagenes\propiedad\" + FilesName + Extension;

                    unidadTrabajo.Propiedade.Add(propiedadVM.Propiedade);
                    unidadTrabajo.Guardar();
                    return RedirectToAction(nameof(Index));
                }
            }
            propiedadVM.ListaVendedor = unidadTrabajo.Vendedor.ListaVendedor();
            return View(propiedadVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            PropiedadVM propiedadVM = new PropiedadVM()
            {
                Propiedade = new Propiedade(),
                ListaVendedor = unidadTrabajo.Vendedor.ListaVendedor()
            };

            if (id is null || id == 0)
            {
                return NotFound();
            }
            propiedadVM.Propiedade = unidadTrabajo.Propiedade.Obtener(id.GetValueOrDefault());
            return View(propiedadVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PropiedadVM propiedadVM)
        {
            if (ModelState.IsValid)
            {
                string WebRootPath = hostEnvironment.WebRootPath;
                var Files = HttpContext.Request.Form.Files;

                var PropiedadDb = unidadTrabajo.Propiedade.Obtener(propiedadVM.Propiedade.Id);

                if (Files.Count() > 0)
                {
                    string FilesName = Guid.NewGuid().ToString();
                    var Upload = Path.Combine(WebRootPath, @"imagenes\propiedad");
                    var Extension = Path.GetExtension(Files[0].FileName);
                    var NuevaExtension = Path.GetExtension(Files[0].FileName);

                    var ImagenUrl = Path.Combine(WebRootPath,PropiedadDb.ImagenUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(ImagenUrl))
                    {
                        System.IO.File.Delete(ImagenUrl);
                    }

                    using (var filesStrems = new FileStream(Path.Combine(Upload, FilesName + NuevaExtension), FileMode.Create))
                    {
                        Files[0].CopyTo(filesStrems);
                    }

                    propiedadVM.Propiedade.ImagenUrl = @"\imagenes\propiedad\" + FilesName + NuevaExtension;

                    unidadTrabajo.Propiedade.Actualizar(propiedadVM.Propiedade);
                    unidadTrabajo.Guardar();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    propiedadVM.Propiedade.ImagenUrl = PropiedadDb.ImagenUrl;
                }

                unidadTrabajo.Propiedade.Actualizar(propiedadVM.Propiedade);
                unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }

            propiedadVM.ListaVendedor = unidadTrabajo.Vendedor.ListaVendedor();
            
            return View();
        }

        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = unidadTrabajo.Propiedade.ObtenerTodo(incluirPropiedades: "Vendedor");
            return Json(new {data = todos});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var propiedadDb = unidadTrabajo.Propiedade.Obtener(id.GetValueOrDefault());

            if (id is null || id == 0)
            {
                return Json(new {success = false, message = "Error al Eliminar la Propiedad"});
            }

            string WebRootPath = hostEnvironment.WebRootPath;
            var ImagenUrl = Path.Combine(WebRootPath,propiedadDb.ImagenUrl.TrimStart('\\'));
            if (System.IO.File.Exists(ImagenUrl))
            {
                System.IO.File.Delete(ImagenUrl);
            }

            unidadTrabajo.Propiedade.Remover(propiedadDb);
            unidadTrabajo.Guardar();
            return Json(new {success = true, message = "Propiedad Eliminada Correctamente"});
        }
        #endregion
    }
}
