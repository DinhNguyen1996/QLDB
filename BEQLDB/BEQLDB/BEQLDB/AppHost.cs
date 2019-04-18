using Funq;
using ServiceStack;
using BEQLDB.ServiceInterface;
using Autofac;
using BEQLDB.ServiceModel;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Configuration;

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

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            IContainerAdapter adapter = new AutofacIocAdapter(builder.Build(), container);
            container.Adapter = adapter;
        }
    }
}