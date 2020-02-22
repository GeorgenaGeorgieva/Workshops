namespace MuOnline.Models.Items.Sets.SoulMasterSets.PosionSet
{
    public class PosionGas : Item
    {
        private const int strengthPoints = 30;
        private const int agilityPoints = 20;
        private const int staminaPoints = 10;
        private const int energyPoints = 5;

        public PosionGas()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
