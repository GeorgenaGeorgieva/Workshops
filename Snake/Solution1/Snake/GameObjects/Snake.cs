namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Enums;
    using Foods;

    public class Snake
    {
        private List<Coordinate> snakeBody;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.Direction = Direction.Right;
            this.InitializeBody();
        }

        public Direction Direction { get; set; }
        
        public IReadOnlyCollection<Coordinate> Body
            => this.snakeBody.AsReadOnly();

        public Coordinate Head
            => this.snakeBody.Last();

        public void Move()
        {
            Coordinate newHead = this.GetNewHeadCoordinate(); 
            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.FoodPoints; i++)
            {
                Coordinate newHeadCoordinate = this.GetNewHeadCoordinate();
                this.snakeBody.Add(newHeadCoordinate);
            }
        }

        private Coordinate GetNewHeadCoordinate()
        {
            Coordinate newHeadCoordinate = new Coordinate(this.Head.CoordinateX, this.Head.CoordinateY);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.CoordinateX++;
                    break;
                case Direction.Left:
                    newHeadCoordinate.CoordinateX--;
                    break;
                case Direction.Down:
                    newHeadCoordinate.CoordinateY++;
                    break;
                case Direction.Up:
                    newHeadCoordinate.CoordinateY--;
                    break;
            }

            return newHeadCoordinate; 
        }

        private void InitializeBody()
        {
            int x = GameConstants.Snake.DefaultX;
            int y = GameConstants.Snake.DefaultY;

            for (int i = 0; i <= GameConstants.Snake.DefaultLength; i++)
            {
                snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
