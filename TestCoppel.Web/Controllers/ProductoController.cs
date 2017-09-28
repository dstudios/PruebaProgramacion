using System;
using System.Web.Mvc;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Web.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public ActionResult Index()
        {
            var model = _productoRepository.GetAll();
            return View(model);
        }

        public ActionResult AddEditItem(int? id)
        {
            var usuario = id.HasValue ? _productoRepository.GetById(id) : new Producto();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult SaveItem(Producto item)
        {
            try
            {
                item.Estatus = true;
                if (item.ProductoID > 0)
                {
                    _productoRepository.Update(item);
                }
                else
                {
                    _productoRepository.Add(item);
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
                var producto = _productoRepository.GetById(id);
                _productoRepository.Delete(producto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}