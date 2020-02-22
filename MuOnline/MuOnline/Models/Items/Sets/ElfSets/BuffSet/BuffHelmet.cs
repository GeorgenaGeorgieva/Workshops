namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffHelmet : Item
    {
        private const int strengthPoints = 20;
        private const int agilityPoints = 50;
        private const int staminaPoints = 60;
        private const int energyPoints = 40;

        public BuffHelmet() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
