namespace MuOnline.Core.Commands
{
    using Contracts;

    using Models.Heroes.HeroContracts;
    using Models.Monsters.Contracts;

    using Repositories.Contracts;

    public class AttackMonsterCommand : ICommand
    {
        private const string CommandMessage = "{0} is dead!";

        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository,
            IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {
            var heroUsername = inputArgs[0];
            var monsterName = inputArgs[1];

            var hero = this.heroRepository.Get(heroUsername);
            var monster = this.monsterRepository.Get(monsterName);

            var heroAttackPoints = hero.TotalAttackPoints;
            var monsterAttackPoints = monster.AttackPoints;

            while (hero.IsAlive && monster.IsAlive)
            {
                hero.TakeDamage(monsterAttackPoints);

                if (!hero.IsAlive)
                {
                    break;
                }

                var experience = monster.TakeDamage(heroAttackPoints);
                ((IProgress)hero).AddExperience(experience);
            }

            var consequences = hero.IsAlive 
                ? monster.GetType().Name 
                : heroUsername;

            return string.Format(CommandMessage, consequences);
        }
    }
}
