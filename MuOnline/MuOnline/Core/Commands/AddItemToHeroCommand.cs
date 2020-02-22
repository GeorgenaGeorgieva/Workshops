namespace MuOnline.Core.Commands
{
    using Contracts;

    using Models.Heroes.HeroContracts;
    using Models.Items.Contracts;

    using Repositories.Contracts;

    public class AddItemToHeroCommand : ICommand
    {
        private const string SuccessfullMessage = "Successfully added {0} to hero {1}.";

        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IItem> itemRepository;

        public AddItemToHeroCommand(IRepository<IHero> heroRepository, IRepository<IItem> itemRepository)
        {
            this.heroRepository = heroRepository;
            this.itemRepository = itemRepository;
        }

        public string Execute(string[] inputArgs)
        {
            var heroUsername = inputArgs[0];
            var itemName = inputArgs[1];

            var hero = this.heroRepository.Get(heroUsername);
            var item = this.itemRepository.Get(itemName);

            hero.Inventory.AddItem(item);

            return string.Format(SuccessfullMessage, item.GetType().Name, heroUsername);
        }
    }
}
