using Autofac;
using Autofac.Integration.Mvc;
using LibMgmtSys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;

namespace LibMgmtSys.TypeContainer
{
    public class Container
    {
        public static void SetDependencyResolver()
        {
            var container = GetContainer();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }

        /// <summary>
        /// 获取Container对象
        /// </summary>
        /// <returns></returns>
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var allAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            var select = new Func<Assembly, Type, IEnumerable<Type>>((assembly, destType) => assembly.GetTypes().Where(t => null != t.GetInterface(destType.FullName)));

            //注入ICache及其实现类
            //var cacheTypes = allAssemblies.SelectMany(a => select(a, typeof(ICache.ICache))).ToArray();
            //if (!cacheTypes.Any())
            //{
            //    throw new RegisterTypeNotFoundException($"未能找到或加载类型{typeof(ICache.ICache).FullName}的实现类型");
            //}

            //builder.RegisterTypes(cacheTypes).As<ICache.ICache>().SingleInstance();

            //注入ILog及其实现类
            var logTypes = allAssemblies.SelectMany(a => select(a, typeof(ILog.ILog))).ToArray(); //日志记录模块
            builder.RegisterTypes(logTypes).As<ILog.ILog>();

            //注入IService及其实现类
            var serviceTypes = allAssemblies.SelectMany(a => select(a, typeof(IService<>))).ToArray();
#pragma warning disable CS0618 // 类型或成员已过时
            Array.ForEach(serviceTypes, type => builder.RegisterGeneric(type).As(typeof(IService<>)).InstancePerHttpRequest()); //服务
#pragma warning restore CS0618 // 类型或成员已过时

            //注入控制器
            var assemblys = allAssemblies.Where(a => select(a, typeof(IController))?.Any() ?? false).ToArray();
            builder.RegisterControllers(assemblys);

            return builder.Build();
        }
    }
}