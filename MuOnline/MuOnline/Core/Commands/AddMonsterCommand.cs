namespace MuOnline.Core.Commands
{
    using Contracts;

    using Factories.Contracts;

    using Models.Monsters.Contracts;

    using Repositories.Contracts;

    public class AddMonsterCommand : ICommand
    {
        private const string SuccessfullMessage = "Successfully created monster: {0}!";

        private readonly IRepository<IMonster> monsterRepository;
        private readonly IMonsterFactory monsterFactory;

        public AddMonsterCommand(IRepository<IMonster> monsterRepository, IMonsterFactory monsterFactory)
        {
            this.monsterRepository = monsterRepository;
            this.monsterFactory = monsterFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var monsterTypeName = inputArgs[0];

            var monster = this.monsterFactory.Create(monsterTypeName);

            this.monsterRepository.Add(monster);

            return string.Format(SuccessfullMessage, monster.GetType().Name);
        }
    }
}
