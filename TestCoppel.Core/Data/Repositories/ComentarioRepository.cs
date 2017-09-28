using System;
using System.Collections.Generic;
using System.Linq;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Core.Data.Repositories
{
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        public List<Comentario> GetAll(int usuarioId)
        {
            return ReadAll().Where(p=>p.Estatus && p.Usuario!= null && p.Usuario.UsuarioID == usuarioId).ToList();
        }
    }
}
