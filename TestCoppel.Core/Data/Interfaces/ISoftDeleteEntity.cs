using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoppel.Core.Data.Interfaces
{
    public interface ISoftDeleteEntity
    {
        bool Estatus { get; set; }
    }
}
