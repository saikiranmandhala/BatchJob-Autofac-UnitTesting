using Autofac;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BatchJobInfrastructure
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = configurationBuilder.Build();


            builder.Register(ctx =>
            {
                return new SmtpSettings(
                                        config.GetSection("smtp:from").Value,
                                        config.GetSection("smtp:port").Value,
                                        config.GetSection("smtp:domain").Value
                                        );
            }).As<SmtpSettings>().SingleInstance();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();

            builder.Register(ctx =>
            {
                return new AppSettings(config);
            }).As<IAppSettings>().SingleInstance();

            builder.RegisterType<EmailHandler>().As<IEmailHandler>().SingleInstance();

            /*   
             *   Below generic code is to register all class types in a module
             *   Same code can be leveraged to register types across projects.
             *   But knowingly limiting this feature to allow each project to have their 
             *   own dependecy injection logic. This helps during individual libraries/projects Unit testing.
            */

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(InfrastructureModule)))
            //    .As(t => t.GetInterfaces().FirstOrDefault(c => c.Name == "I" + c.Name));


            //base.Load(builder);
        }
    }
}
