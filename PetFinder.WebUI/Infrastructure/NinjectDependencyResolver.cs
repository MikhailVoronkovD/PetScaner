﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using PetFinder.Domain.Abstract;
using PetFinder.Domain.Concrete;
using PetFinder.WebUI.Infrastructure.Abstract;
using PetFinder.WebUI.Infrastructure.Concrete;

namespace PetFinder.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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
            kernel.Bind<IAdvertisementRepository>().To<EFAdvertisementRepository>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}