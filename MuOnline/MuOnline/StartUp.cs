namespace MuOnline
{
    using System;

    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;

    using Microsoft.Extensions.DependencyInjection;

    using Models.Heroes.HeroContracts;
    using Models.Items.Contracts;
    using Models.Monsters.Contracts;

    using Repositories;
    using Repositories.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IHeroFactory, HeroFactory>();
            serviceCollection.AddTransient<IMonsterFactory, MonsterFactory>();
            serviceCollection.AddTransient<IItemFactory, ItemFactory>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddSingleton<IRepository<IHero>, HeroRepository>();
            serviceCollection.AddSingleton<IRepository<IMonster>, MonsterRepository>();
            serviceCollection.AddSingleton<IRepository<IItem>, ItemRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
