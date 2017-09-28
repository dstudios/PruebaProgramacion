using System;
using System.ComponentModel.DataAnnotations;
using TestCoppel.Core.Data.Interfaces;

namespace TestCoppel.Core.Data.Models
{
    public class Usuario : ISoftDeleteEntity
    {
        [Key]
        public int UsuarioID { get; set; }

        [MaxLength(3)]
        public string Clave { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Estatus { get; set; }
    }
}
