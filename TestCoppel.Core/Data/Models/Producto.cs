using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestCoppel.Core.Data.Interfaces;

namespace TestCoppel.Core.Data.Models
{
    public class Producto : ISoftDeleteEntity
    {
        [Key]
        public int ProductoID { get; set; }

        [MaxLength(20)]
        public string Description { get; set; }
        public bool Estatus { get; set; }

        public virtual List<Proveedor> Proveedores { get; set; }
    }
}
