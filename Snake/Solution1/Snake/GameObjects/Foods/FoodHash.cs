namespace SimpleSnake.GameObjects.Foods
{
    using Constants;

    public class FoodHash : Food
    {
        public FoodHash(Coordinate coordinate)
            : base(GameConstants.Food.SymbolHash, GameConstants.Food.PointsHash, coordinate)
        {
        }
    }
}
