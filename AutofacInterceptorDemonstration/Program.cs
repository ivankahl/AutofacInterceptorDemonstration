using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutofacInterceptorDemonstration.Interceptors;
using AutofacInterceptorDemonstration.Services;

namespace AutofacInterceptorDemonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            // Create a lifetime scope which we can use to resolve services
            // https://autofac.readthedocs.io/en/latest/resolve/index.html#resolving-services
            using var scope = container.BeginLifetimeScope();

            var labelMaker = scope.Resolve<ConsoleLabelMaker>();

            // Prompt the user for label contents
            Console.Write("Please enter label contents: ");
            var contents = Console.ReadLine();

            // Output dimensions
            var dimensions = labelMaker.CalculateLabelSize(contents);
            Console.WriteLine($"Label size will be: {dimensions.width} x {dimensions.height}");

            // Print the label
            labelMaker.Print(contents);
        }

        /// <summary>
        /// Builds an Autofac container with the necessary services.
        /// </summary>
        /// <returns>
        /// Autofac container that can be used to resolve services.
        /// </returns>
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // First register our interceptors
            builder.RegisterType<LoggingInterceptor>();

            // Register our label maker service as a singleton
            // (so we only create a single instance)
            builder.RegisterType<ConsoleLabelMaker>()
                .SingleInstance()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(LoggingInterceptor));

            return builder.Build();
        }
    }
}
