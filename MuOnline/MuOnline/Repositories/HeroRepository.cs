namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Models.Heroes.HeroContracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository
            => this.heroes.AsReadOnly();

        public void Add(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Invalid hero!");
            }

            this.heroes.Add(hero);
        }

        public bool Remove(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Invalid hero!");
            }

            bool isRemoved = this.heroes.Remove(hero);

            return isRemoved;
        }

        public IHero Get(string hero)
        {
            var targetHero = this.heroes
                .FirstOrDefault(h => ((IIdentifiable)h).Username == hero);

            if (targetHero == null)
            {
                throw new ArgumentNullException("Invalid hero!");
            }

            return targetHero;
        }
    }
}
