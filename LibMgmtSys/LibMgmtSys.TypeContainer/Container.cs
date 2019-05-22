using Autofac;
using Autofac.Integration.Mvc;
using LibMgmtSys.ICache;
using LibMgmtSys.IDAL;
using LibMgmtSys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        //Get container
        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var allAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            var select = new Func<Assembly, Type, IEnumerable<Type>>((assembly, destType) => assembly.GetTypes().Where(t => null != t.GetInterface(destType.FullName)));

            //注入ICache及其实现类
            var cacheTypes = allAssemblies.SelectMany(a => select(a, typeof(ICache.ICache))).ToArray();
            if (!cacheTypes.Any())
            {
                throw new RegisterTypeNotFoundException($"未能找到或加载类型{typeof(ICache.ICache).FullName}的实现类型");
            }

            builder.RegisterTypes(cacheTypes).As<ICache.ICache>().SingleInstance();

            //注入IDAL及其实现类
            var dalTypes = allAssemblies.SelectMany(a => select(a, typeof(IDAL<>))).ToArray();
            Array.ForEach(dalTypes, type => builder.RegisterGeneric(type).As(typeof(IDAL<>))); //泛型注入

            //注入IDALAsync及其实现类（数据的异步操作）
            var dalAsyncTypes = allAssemblies.SelectMany(a => select(a, typeof(IDALAsync<>))).ToArray();
            Array.ForEach(dalAsyncTypes, type => builder.RegisterGeneric(type).As(typeof(IDALAsync<>))); //泛型注入

            //注入IService及其实现类
            var serviceTypes = allAssemblies.SelectMany(a => select(a, typeof(IService<>))).ToArray();
            Array.ForEach(serviceTypes, type => builder.RegisterGeneric(type).As(typeof(IService<>))); //泛型注入
            
            //注入控制器
            var assemblys = allAssemblies.Where(a => select(a, typeof(IController))?.Any() ?? false).ToArray();
            builder.RegisterControllers(assemblys);

            return builder.Build();
        }
    }
}