using System;
using Autofac;
using WebTool.Views;
using WebTool.ViewModels;
using WebTool.Services.DataBreach;
using WebTool.Services.DeviceInfo;
using WebTool.Services.DomainDatabase;
using WebTool.Services.ServerMonitor;

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
            builder.RegisterType<DomainDatabasePage>().SingleInstance();

            //ViewModels
            builder.RegisterType<DataBreachViewModel>().SingleInstance();
            builder.RegisterType<DeviceInfoViewModel>().SingleInstance();
            builder.RegisterType<DomainDatabaseViewModel>().SingleInstance();

            //Services
            builder.RegisterType<DataBreachService>().As<IDataBreachService>();
            builder.RegisterType<DeviceInfoService>().As<IDeviceInfoService>();
            builder.RegisterType<DomainDatabaseService>().As<IDomainDatabaseService>();
            builder.RegisterType<ServerMonitorService>().As<IServerMonitorService>();

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
