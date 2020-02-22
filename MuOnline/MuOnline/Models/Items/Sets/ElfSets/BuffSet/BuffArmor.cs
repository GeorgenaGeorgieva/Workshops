namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 30;
        private const int staminaPoints = 25;
        private const int energyPoints = 90;

        public BuffArmor()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
