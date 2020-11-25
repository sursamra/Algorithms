using System;

namespace Algorithms
{
    static class Car_fueling_gas_Station
    {
        public static void Test1()
        {
            int[] cars = { 2, 8, 4, 3, 2 };
            int x = 7, y = 11, z = 3;
            Console.WriteLine(CanFill(cars, x, y, z));

        }
        public static void Test2()
        {
            int[] cars = { 5 };
            int x = 4, y = 0, z = 3;
            Console.WriteLine(CanFill(cars, x, y, z));

        }
        public static int CanFill(int[] cars, int xRemainingGas, int yRemainingGas, int zRemainingGas)
        {
            int time = 0, currentCarIndex = 0, xOccupied = 0, yOccupied = 0, zOccupied = 0;
            while (currentCarIndex < cars.Length)
            {
                int currentCar = cars[currentCarIndex];
                bool xHasEnoughGas = xRemainingGas >= currentCar;
                bool yHasEnoughGas = yRemainingGas >= currentCar;
                bool zHasEnoughGas = zRemainingGas >= currentCar;
                if (!xHasEnoughGas && !yHasEnoughGas && !zHasEnoughGas)
                {
                    return -1;
                }

                bool xPossible = xHasEnoughGas && xOccupied <= 0;
                bool yPossible = yHasEnoughGas && yOccupied <= 0;
                bool zPossible = zHasEnoughGas && zOccupied <= 0;

                if (xPossible)
                {
                    xOccupied = currentCar;
                    xRemainingGas -= currentCar;
                    currentCarIndex++;
                }
                else if (yPossible)
                {
                    yOccupied = currentCar;
                    yRemainingGas -= currentCar;
                    currentCarIndex++;
                }
                else if (zPossible)
                {
                    zOccupied = currentCar;
                    zRemainingGas -= currentCar;
                    currentCarIndex++;
                }
                else
                {
                    int minWaitTime = xOccupied > 0 ? xOccupied : int.MaxValue;
                    minWaitTime = yOccupied > 0 ? Math.Min(minWaitTime, yOccupied) : minWaitTime;
                    minWaitTime = zOccupied > 0 ? Math.Min(minWaitTime, zOccupied) : minWaitTime;

                    time += minWaitTime;
                    xOccupied -= minWaitTime;
                    yOccupied -= minWaitTime;
                    zOccupied -= minWaitTime;
                }
            }

            return time;
        }
    }
}
