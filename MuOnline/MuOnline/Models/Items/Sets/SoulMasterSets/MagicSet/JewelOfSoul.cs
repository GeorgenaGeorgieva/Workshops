namespace MuOnline.Models.Items.Sets.SoulMasterSets.MagicSet
{
    public class JewelOfSoul : Item
    {
        private const int strengthPoints = 60;
        private const int agilityPoints = 40;
        private const int staminaPoints = 0;
        private const int energyPoints = 30;

        public JewelOfSoul()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
