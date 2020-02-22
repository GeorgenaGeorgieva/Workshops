namespace SimpleSnake.Constants
{
    public static class GameConstants
    {
        public static class Snake
        {
            public static readonly string Symbol = "\u25CF";
            public static readonly int DefaultLength = 6;
            public static readonly int DefaultX = 8;
            public static readonly int DefaultY = 7;
        }
        public static class Food
        {
            public static readonly string SymbolAsterisk = "*";
            public static readonly int PointsAsterisk = 1;
            public static readonly string SymbolDollar = "$";
            public static readonly int PointsDollar = 2;
            public static readonly string SymbolHash = "#";
            public static readonly int PointsHash = 3;
        }

        public static class Board
        {
            public static readonly int DefaultBoardWidth = 120;
            public static readonly int DefaultBoardHeight = 40;
            public static readonly string DefaultBoardSymbol = "\u2588";
        }

        public static class Player
        {
            public static readonly int PlayerScoreOffsetX = 3;
            public static readonly int PlayerScoreOffsetY = 10;
            public static readonly string PlayerScore = "Game score: {0}";
        }

        public static class Config
        {
            public static readonly int EndMessageX = 40;
            public static readonly int EndMessageY = 20;
            public static readonly string EndMessage = "Would you like to continue?";
            public static readonly string EndMessageOption = "Press: Y/N";
        }
    }
}
