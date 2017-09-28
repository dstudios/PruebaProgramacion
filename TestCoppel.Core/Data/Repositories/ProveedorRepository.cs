using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Models;

namespace TestCoppel.Core.Data.Repositories
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public List<Proveedor> GetAll()
        {
            return ReadAll().Where(p => p.Estatus).ToList();
        }
    }
}
