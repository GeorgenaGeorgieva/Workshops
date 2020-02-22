namespace SimpleSnake.GameObjects.Foods
{
    using Constants;

    public class FoodDollar : Food
    {
        public FoodDollar(Coordinate coordinate)
            : base(GameConstants.Food.SymbolDollar, GameConstants.Food.PointsDollar, coordinate)
        {
        }
    }
}
