using Microsoft.Practices.Unity;
using System;
using System.Linq;

namespace AbdulPriceBasket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new UnityContainer();
                container.RegisterType<StartUp, StartUp>();

                // Registering my all dependencies..
                UnityConfig.RegisterTypes(container);
                // Let Unity resolve StartUp and create a build plan.
                var program = container.Resolve<StartUp>();

                var consoleUserInput = args.ToList();
                program.Run(consoleUserInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
