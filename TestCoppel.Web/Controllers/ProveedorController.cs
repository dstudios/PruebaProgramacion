using System;
using System.Web.Mvc;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public ActionResult Index()
        {
            var model = _proveedorRepository.GetAll();
            return View(model);
        }

        public ActionResult AddEditItem(int? id)
        {
            var usuario = id.HasValue ? _proveedorRepository.GetById(id) : new Proveedor();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult SaveItem(Proveedor item)
        {
            try
            {
                item.Estatus = true;
                if (item.ProveedorID > 0)
                {
                    _proveedorRepository.Update(item);
                }
                else
                {
                    _proveedorRepository.Add(item);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("AddEditItem");
            }
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                var proveedor = _proveedorRepository.GetById(id);
                _proveedorRepository.Delete(proveedor);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}