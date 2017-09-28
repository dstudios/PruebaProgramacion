using System;
using System.Web.Mvc;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Index()
        {
            var model = _usuarioRepository.GetAll();
            return View(model);
        }

        public ActionResult AddEditItem(int? id)
        {
            var usuario = id.HasValue ? _usuarioRepository.GetById(id) : new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult SaveItem(Usuario item)
        {
            try
            {
                item.Estatus = true;
                if (item.UsuarioID > 0)
                {
                    _usuarioRepository.Update(item);
                }
                else
                {
                    _usuarioRepository.Add(item);
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
                var usuario = _usuarioRepository.GetById(id);
                _usuarioRepository.Delete(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}