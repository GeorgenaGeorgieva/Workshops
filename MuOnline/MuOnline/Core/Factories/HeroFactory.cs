namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    using Models.Heroes.HeroContracts;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            var heroName = heroType.ToLower();

            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(h => h.Name.ToLower() == heroName);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid hero type!");
            }

            var hero = (IHero)Activator.CreateInstance(type, username);

            return hero;
        }
    }
}
