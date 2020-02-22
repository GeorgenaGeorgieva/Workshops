namespace MuOnline.Core
{
    using System;

    using Contracts;

    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var inputArguments = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter = serviceProvider
                        .GetService<ICommandInterpreter>();

                    var result = commandInterpreter.Read(inputArguments);

                    Console.WriteLine(result);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }
                catch (InvalidOperationException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }
    }
}
