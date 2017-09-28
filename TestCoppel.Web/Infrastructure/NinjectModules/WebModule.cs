using Ninject.Modules;
using TestCoppel.Core.Data.Interfaces;
using TestCoppel.Core.Data.Repositories;

namespace TestCoppel.Web.Infrastructure.NinjectModules
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Kernel.Bind<IComentarioRepository>().To<ComentarioRepository>();
            Kernel.Bind<IProveedorRepository>().To<ProveedorRepository>();
            Kernel.Bind<IProductoRepository>().To<ProductoRepository>();
        }
    }
}