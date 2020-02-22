namespace SimpleSnake
{
    using Constants;
    using Core;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();
            Coordinate boardCoordinate = new Coordinate(GameConstants.Board.DefaultBoardWidth, 
                GameConstants.Board.DefaultBoardHeight);

            Engine engine = new Engine(drawManager, snake, boardCoordinate);
            engine.Run();
        }
    }
}
