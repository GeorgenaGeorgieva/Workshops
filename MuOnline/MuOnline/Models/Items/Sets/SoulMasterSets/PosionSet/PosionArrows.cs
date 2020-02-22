namespace MuOnline.Models.Items.Sets.SoulMasterSets.PosionSet
{
    public class PosionArrows : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 30;
        private const int staminaPoints = 40;
        private const int energyPoints = 0;

        public PosionArrows()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
