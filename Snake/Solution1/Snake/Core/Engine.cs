namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Constants;
    using Enums;
    using GameObjects;
    using GameObjects.Foods;

    public class Engine
    {
        private DrawManager drawManager;
        private Snake snake;
        private Food food;
        private Coordinate boardCoordinate;
        private int gameScore;

        public Engine(DrawManager drawManager, Snake snake, Coordinate boardCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.food = new FoodHash(new Coordinate(20, 20));
            this.boardCoordinate = boardCoordinate;

            this.InitializeFood();
            this.InitializeBorders();
        }

        public void Run()
        {
            while (true)
            {
                this.PlayerInfo();

                if (Console.KeyAvailable)
                {
                    this.SetCorrectDirection(Console.ReadKey());
                }

                this.drawManager.Draw(this.food.FoodSymbol, new List<Coordinate> { food.Coordinate });

                this.drawManager.Draw(GameConstants.Snake.Symbol, this.snake.Body);

                this.snake.Move();

                this.drawManager.UndoDraw();

                if (HasFoodCollision())
                {
                    this.snake.Eat(this.food);
                    this.gameScore += this.food.FoodPoints;
                    this.InitializeFood();
                }

                if (HasBoardCollision())
                {
                    this.AskPlayerForRestart();
                }

                if (this.snake.Direction == Direction.Down ||this.snake.Direction == Direction.Up)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }

        private void PlayerInfo()
        {
            int x = GameConstants.Board.DefaultBoardWidth + GameConstants.Player.PlayerScoreOffsetX;
            int y = GameConstants.Player.PlayerScoreOffsetY;

            Console.SetCursorPosition(x, y);
            Console.Write(string.Format(GameConstants.Player.PlayerScore, this.gameScore));
        }

        private void AskPlayerForRestart()
        {
            Console.SetCursorPosition(GameConstants.Config.EndMessageX, GameConstants.Config.EndMessageY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(GameConstants.Config.EndMessage);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(GameConstants.Config.EndMessageOption);

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                return;
            }
        }

        private bool HasBoardCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int boardCoordinateX = this.boardCoordinate.CoordinateX;
            int boardCoordinateY = this.boardCoordinate.CoordinateY;

            return snakeHeadCoordinateX == boardCoordinateX - 1
                || snakeHeadCoordinateX == 0
                || snakeHeadCoordinateY == boardCoordinateY
                || snakeHeadCoordinateY == 0;
          
        }

        private void InitializeBorders()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();

            this.InitializeHorizontalBorderCoordinates(0, allCoordinates);
            this.InitializeHorizontalBorderCoordinates(this.boardCoordinate.CoordinateY, allCoordinates);
            this.InitializeVerticalBorderCoordinates(0, allCoordinates);
            this.InitializeVerticalBorderCoordinates(this.boardCoordinate.CoordinateX - 1, allCoordinates);

            this.drawManager.Draw(GameConstants.Board.DefaultBoardSymbol, allCoordinates);
        }

        private void InitializeVerticalBorderCoordinates(int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int coordinateY = 0; coordinateY < this.boardCoordinate.CoordinateY; coordinateY++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeHorizontalBorderCoordinates(int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int coordinateX = 0; coordinateX < this.boardCoordinate.CoordinateX; coordinateX++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeFood()
        {
            this.food = FactoryFood.GenerateRandomFood(this.boardCoordinate.CoordinateX, 
                this.boardCoordinate.CoordinateY);
        }
        
        private bool HasFoodCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int foodCoordinateX = this.food.Coordinate.CoordinateX;
            int foodCoordinateY = this.food.Coordinate.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX 
                && snakeHeadCoordinateY == foodCoordinateY;
        }

        private void SetCorrectDirection(ConsoleKeyInfo input)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }
    }
}
