namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffPants : Item
    {
        private const int strengthPoints = 50;
        private const int agilityPoints = 13;
        private const int staminaPoints = 16;
        private const int energyPoints = 0;

        public BuffPants()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
