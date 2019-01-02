using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using gellmvc.Domain.Abstract;
using gellmvc.Domain.Concrete;
using gellmvc.Domain.Entities;

namespace gellmvc.Infrastructure
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
      //Mock<IProductRepository> mock = new Mock<IProductRepository>();
      //mock.Setup(m => m.Products).Returns(new List<Product> {
      //  new Product{
      //    Name = "Metal Gear Motor",
      //    Description = "12V motor with a 100:1 metal gearbox",
      //    UnitPrice = 59.75M
      //  },

      //  new Product{
      //    Name = "Mini Photocell SEN-09088",
      //    Description = "A photoconductive cell. Resistance varies according to the amount of light it is exposed to.",
      //    UnitPrice = 1.67M
      //  },

      //  new Product{
      //    Name = "PCB Holder with Magnifying Glass",
      //    Description = "Magnifying Glass: 90mm",
      //    UnitPrice = 12.95M
      //  }
      //});
      //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

      kernel.Bind<IProductRepository>().To<EFProductRepository>();
    }
  }
}