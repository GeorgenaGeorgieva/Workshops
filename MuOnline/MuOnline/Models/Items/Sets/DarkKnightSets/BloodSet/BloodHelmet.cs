namespace MuOnline.Models.Items.Sets.DarkKnightSets.BloodSet
{
    public class BloodHelmet : Item
    {
        private const int strengthPoints = 20;
        private const int agilityPoints = 10;
        private const int staminaPoints = 40;
        private const int energyPoints = 0;

        public BloodHelmet()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
