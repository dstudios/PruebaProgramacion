using System.Collections.Generic;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Web.Models
{
    public class ComentariosViewModel
    {
        public Usuario Usuario { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}