namespace MuOnline.Core.Commands
{
    using Contracts;

    using Factories.Contracts;

    using Models.Heroes.HeroContracts;

    using Repositories.Contracts;

    public class AddHeroCommand : ICommand
    {
        private const string SuccessfullyMessage = "Successfully created hero: {0}!";

        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> heroRepository, IHeroFactory heroFactory)
        {
            this.heroRepository = heroRepository;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var heroType = inputArgs[0];
            var username = inputArgs[1];

            var hero = this.heroFactory.Create(heroType, username);

            this.heroRepository.Add(hero);

            return string.Format(SuccessfullyMessage, username);
        }
    }
}
