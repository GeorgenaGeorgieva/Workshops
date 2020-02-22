namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffGloves : Item
    {
        private const int strengthPoints = 15;
        private const int agilityPoints = 10;
        private const int staminaPoints = 30;
        private const int energyPoints = 5;

        public BuffGloves() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
