namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GameObjects;
    using GameObjects.Foods;

    public static class FactoryFood
    {
        private static Random random;

        static FactoryFood()
        {
            random = new Random();
        }

        public static Food GenerateRandomFood(int boardWidth, int boardHeight)
        {
            List<Type> foodType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.BaseType == typeof(Food))
                .ToList();

            Type currentType = foodType[random.Next(0, foodType.Count)];

            int coordinateX = random.Next(1, boardWidth);
            int coordinateY = random.Next(1, boardHeight);

            Coordinate foodCoordinate = new Coordinate(coordinateX, coordinateY);

            return Activator.CreateInstance(currentType, new object[] { foodCoordinate }) as Food;
        }
    }
}
