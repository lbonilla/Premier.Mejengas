using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Concrete;
using Mejenguitas_UI.Infrastructure.Abstract;
using Mejenguitas_UI.Infrastructure.Concrete;
using Ninject;

namespace Mejenguitas_UI.Infrastructure
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependecyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {            
            kernel.Bind<IJuegoRepository>().To<EFJuegoRepository>();
            kernel.Bind<IJugadorRepository>().To<EFJugadorRepository>();
<<<<<<< HEAD
            kernel.Bind<IGaleriaRepository>().To<EFGaleriaRepository>();
=======

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
>>>>>>> 955e362792c7eac3233b730422e43f03aaaf6208
        }
    }
}