﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac;

public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
       builder.RegisterType<CarManager>().As<ICarService>();
       builder.RegisterType<EFCarDal>().As<ICarDal>();

       builder.RegisterType<BrandManager>().As<IBrandService>();
       builder.RegisterType<EFBrandDal>().As<IBrandDal>();

       builder.RegisterType<ColorManager>().As<IColorService>();
       builder.RegisterType<EFColorDal>().As<IColorDal>();

       builder.RegisterType<UserManager>().As<IUserService>();
       builder.RegisterType<EfUserDal>().As<IUserDal>();
       
       builder.RegisterType<CustomerManager>().As<ICustomerService>();
       builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
      
       builder.RegisterType<RentalManager>().As<IRentalService>();
       builder.RegisterType<EfRentalDal>().As<IRentalDal>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();



    }


}
