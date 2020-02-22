namespace MuOnline.Models.Items.Sets.SoulMasterSets.PosionSet
{
    public class PosionRain : Item
    {
        private const int strengthPoints = 15;
        private const int agilityPoints = 10;
        private const int staminaPoints = 0;
        private const int energyPoints = 30;

        public PosionRain() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
