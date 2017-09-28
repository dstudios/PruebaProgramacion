using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestCoppel.Core.Data.Interfaces;

namespace TestCoppel.Core.Data.Models
{
    public class Comentario : ISoftDeleteEntity
    {
        [Key]
        public int ComentarioID { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }


        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public bool Estatus { get; set; }
    }
}
