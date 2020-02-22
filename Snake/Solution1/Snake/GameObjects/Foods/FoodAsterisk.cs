namespace SimpleSnake.GameObjects.Foods
{
    using Constants;

    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Coordinate coordinate) 
            : base(GameConstants.Food.SymbolAsterisk, GameConstants.Food.PointsAsterisk, coordinate)
        {
        }
    }
}
