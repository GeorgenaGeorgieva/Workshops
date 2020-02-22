namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(string foodSymbol, int foodPoints, Coordinate coordinate)
        {
            this.FoodPoints = foodPoints;
            this.FoodSymbol = foodSymbol;
            this.Coordinate = coordinate;
        }

        public int FoodPoints  { get; set; }
        public string FoodSymbol { get; set; }
        public Coordinate Coordinate{ get; set; }
    }
}
