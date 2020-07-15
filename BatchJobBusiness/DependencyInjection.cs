using Autofac;
using BatchJobDataAccess;
using BatchJobInfrastructure;

namespace BatchJobBusiness
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Business>().As<IBusiness>();

            /*   
             *   Below generic code is to register all class types in a module
             *   Same code can be leveraged to register types across projects.
             *   But knowingly limiting this feature to allow each project to have their 
             *   own dependecy injection logic. This helps during individual libraries/projects Unit testing.
            */

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(BatchJobBusiness)))
            //    .As(t => t.GetInterfaces().FirstOrDefault(c => c.Name == "I" + c.Name));

            builder.RegisterModule<DataAccessModule>();
            builder.RegisterModule<InfrastructureModule>();



            //base.Load(builder);
        }
    }
}
