namespace MuOnline.Models.Items.Sets.SoulMasterSets.PosionSet
{
    public class PosionRing : Item
    {
        private const int strengthPoints = 30;
        private const int agilityPoints = 5;
        private const int staminaPoints = 15;
        private const int energyPoints = 40;

        public PosionRing() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
