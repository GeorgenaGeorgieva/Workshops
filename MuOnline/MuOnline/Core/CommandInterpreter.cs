namespace MuOnline.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Commands.Contracts;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            var commandName = args[0].ToLower() + Suffix;
            var inputArgs = args.Skip(1).ToArray();

            var classType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (classType == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            var constructor = classType
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var cervices = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var typeInstance = (ICommand)Activator.CreateInstance(classType, cervices);
            var result = typeInstance.Execute(inputArgs);

            return result;
        }
    }
}
