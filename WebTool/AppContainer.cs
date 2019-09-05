using System;
using Autofac;
using WebTool.Views;
using WebTool.ViewModels;
using WebTool.Services.DataBreach;
using WebTool.Services.DeviceInfo;

namespace WebTool
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //Views
            builder.RegisterType<DataBreachPage>().SingleInstance();
            builder.RegisterType<DeviceInfoPage>().SingleInstance();

            //ViewModels
            builder.RegisterType<DataBreachViewModel>().SingleInstance();
            builder.RegisterType<DeviceInfoViewModel>().SingleInstance();

            //Services
            builder.RegisterType<DataBreachService>().As<IDataBreachService>();
            builder.RegisterType<DeviceInfoService>().As<IDeviceInfoService>();


            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
