using System;
using System.Linq;
using Castle.DynamicProxy;

namespace AutofacInterceptorDemonstration.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        /// <inheritdoc />
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Executing {0} with parameters: {1}",
                $"{invocation.MethodInvocationTarget.DeclaringType?.FullName}.{invocation.Method.Name}",
                string.Join(", ", invocation.Arguments.Select(a => a?.ToString()).ToArray()));

            // Invoke the method
            invocation.Proceed();

            Console.WriteLine("Finised executing {0}", 
                $"{invocation.MethodInvocationTarget.DeclaringType?.FullName}.{invocation.Method.Name}");
        }
    }
}