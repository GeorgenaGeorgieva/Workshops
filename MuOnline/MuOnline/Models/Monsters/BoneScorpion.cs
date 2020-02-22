namespace MuOnline.Models.Monsters
{
    public class BoneScorpion : Monster
    {
        private const int attackPoints = 100;
        private const int vitalityPoints = 80;

        public BoneScorpion()
            : base(attackPoints, vitalityPoints)
        {
        }
    }
}
