using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Core.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        List<Usuario> GetAll();
    }
}
