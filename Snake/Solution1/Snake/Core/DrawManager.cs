namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameObjects;

    public class DrawManager
    {
        private const string SnakeSymbol = "\u25CF";
        private List<Coordinate> snakeBodyElements;
        
        public DrawManager()
        {
            this.snakeBodyElements = new List<Coordinate>();
        }

        public void Draw(string symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == SnakeSymbol)
                {
                    this.snakeBodyElements.Add(coordinate);
                }

                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            Coordinate lastElement = this.snakeBodyElements.First();

            Console.SetCursorPosition(lastElement.CoordinateX, lastElement.CoordinateY);
            Console.WriteLine(" ");
            this.snakeBodyElements.Clear();
        }
    }
}
