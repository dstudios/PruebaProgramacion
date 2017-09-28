using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestCoppel.Core.Data.Interfaces;

namespace TestCoppel.Core.Data.Models
{
    public class Proveedor : ISoftDeleteEntity
    {
        [Key]
        public int ProveedorID { get; set; }

        [MaxLength(13)]
        public string RFC { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; }
        public bool Estatus { get; set; }
        public virtual List<Producto> Productos { get; set; }
    }
}
