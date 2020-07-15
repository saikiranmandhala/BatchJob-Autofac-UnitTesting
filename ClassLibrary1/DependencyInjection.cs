using Autofac;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BatchJobDataAccess
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = configurationBuilder.Build();

            builder.Register(ctx =>
            {
                return new DataAccess(
                                        config.GetSection("connectionString").Value
                                        );
            }).As<IDataAccess>().SingleInstance();


            /*   
             *   Below generic code is to register all class types in a module
             *   Same code can be leveraged to register types across projects.
             *   But knowingly limiting this feature to allow each project to have their 
             *   own dependecy injection logic. This helps during individual libraries/projects Unit testing.
            */

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(DataAccessModule)))
            //    .As(t => t.GetInterfaces().FirstOrDefault(c => c.Name == "I" + c.Name));



            //base.Load(builder);
        }
    }
}
