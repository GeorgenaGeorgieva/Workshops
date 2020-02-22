namespace MuOnline.Models.Items.Sets.SoulMasterSets.MagicSet
{
    public class MasterScepter : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 15;
        private const int staminaPoints = 20;
        private const int energyPoints = 0;

        public MasterScepter()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
