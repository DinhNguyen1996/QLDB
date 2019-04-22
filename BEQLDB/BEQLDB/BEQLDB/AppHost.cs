using Funq;
using ServiceStack;
using BEQLDB.ServiceInterface;
using Autofac;
using BEQLDB.ServiceModel;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Configuration;
using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceInterface.DAL.UnitOfWork;
using BEQLDB.ServiceInterface.DAL.Interface;

namespace BEQLDB
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("BEQLDB", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            var builder = new ContainerBuilder();
            // Register Database context
            builder.Register(c =>
            {
                var contextOption = new DbContextOptionsBuilder<QLDBContext>()
               .UseSqlServer(AppSettings.GetString("ConnectionString"))
               .Options;
                return new QLDBContext(contextOption);
            }).InstancePerRequest();

            //// Register repository
            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //    .As(typeof(IGenericRepository<>))
            //    .InstancePerRequest();

            //
            container.RegisterAutoWiredAs<NetworkRepository, INetworkRepository>().ReusedWithin(ReuseScope.Request);

            // register UnitofWork
            builder.RegisterGeneric(typeof(UnitOfWork<>))
                .As(typeof(IUnitOfWork<>))
                .InstancePerRequest();

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            IContainerAdapter adapter = new AutofacIocAdapter(builder.Build(), container);
            container.Adapter = adapter;



        }
    }
}