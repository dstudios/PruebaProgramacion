using System;
using System.Web.Mvc;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;
using TestCoppel.Web.Models;

namespace TestCoppel.Web.Controllers
{
    public class ComentarioController : Controller
    {
        private IComentarioRepository _comentarioRepository;
        private IUsuarioRepository _usuarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository, IUsuarioRepository usuarioRepository)
        {
            _comentarioRepository = comentarioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Index(int usuarioId)
        {
            var comentarios = _comentarioRepository.GetAll(usuarioId);
            var usuario = _usuarioRepository.GetById(usuarioId);

            var model = new ComentariosViewModel() {
                Usuario = usuario,
                Comentarios = comentarios
            };

            return View(model);
        }

        public ActionResult AddEditItem(int usuarioId, int? id)
        {
            var comentario = id.HasValue ? _comentarioRepository.GetById(id) : new Comentario();
            comentario.Usuario = comentario.Usuario ?? _usuarioRepository.GetById(usuarioId);
            return View(comentario);
        }

        [HttpPost]
        public ActionResult SaveItem(int usuarioId, Comentario item)
        {
            try
            {
                item.Estatus = true;
                item.UsuarioId = usuarioId;
                if (item.ComentarioID > 0)
                {
                    _comentarioRepository.Update(item);
                }
                else
                {
                    _comentarioRepository.Add(item);
                }
                return RedirectToAction("Index", new { usuarioId = usuarioId });
            }
            catch (Exception)
            {
                return View("AddEditItem", new { usuarioId = usuarioId });
            }
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                var comentario = _comentarioRepository.GetById(id);
                _comentarioRepository.Delete(comentario);
                return RedirectToAction("Index", new { usuarioId = id });
            }
            catch (Exception)
            {
                return View("Index", new { usuarioId = id });
            }
        }
    }
}