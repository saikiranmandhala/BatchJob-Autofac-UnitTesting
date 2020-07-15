using Autofac;
using System;

namespace BatchJobEntryConsole
{
    /// <summary>
    /// Author: Saikiran Mandhala
    /// Email: saikiran.mandhala@gmail.com
    /// Date: 15/07/2020
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            var container = DependencyInjectionContainer.Configure();


            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run();
            }
            Console.ReadLine();
        }
    }
}
