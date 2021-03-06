﻿using System;
using System.Collections.Generic;
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
            List<string> list = new List<string>();
            Logger.Init("Car_fuel");
            while (currentCarIndex < cars.Length)
            {
                Logger.Log(0, currentCarIndex);

                int currentCar = cars[currentCarIndex];
                Logger.Log(1, $"currentCar {currentCar}");

                bool xHasEnoughGas = xRemainingGas >= currentCar;
                bool yHasEnoughGas = yRemainingGas >= currentCar;
                bool zHasEnoughGas = zRemainingGas >= currentCar;
                Logger.Log(1, $"xHasEnoughGas {xHasEnoughGas} yHasEnoughGas {yHasEnoughGas} zHasEnoughGas {zHasEnoughGas}");
                if (!xHasEnoughGas && !yHasEnoughGas && !zHasEnoughGas)
                {
                    Logger.Log(1, $"xHasEnoughGas {xHasEnoughGas} yHasEnoughGas {yHasEnoughGas} zHasEnoughGas {zHasEnoughGas} return -1");
                    return -1;
                }

                bool xPossible = xHasEnoughGas && xOccupied <= 0;
                bool yPossible = yHasEnoughGas && yOccupied <= 0;
                bool zPossible = zHasEnoughGas && zOccupied <= 0;

                Logger.Log(1, $"xPossible {xPossible} yPossible {yPossible} zPossible {zPossible}");
                if (xPossible)
                {

                    xOccupied = currentCar;
                    xRemainingGas -= currentCar;
                    currentCarIndex++;
                    Logger.Log(2, $"xPossible {xPossible} ");
                    Logger.Log(2, $"xOccupied {xOccupied} xRemainingGas {xRemainingGas} currentCarIndex {currentCarIndex}");
                }
                else if (yPossible)
                {
                    yOccupied = currentCar;
                    yRemainingGas -= currentCar;
                    currentCarIndex++;
                    Logger.Log(2, $"yPossible {yPossible} ");
                    Logger.Log(2, $"yOccupied {yOccupied} yRemainingGas {yRemainingGas} currentCarIndex {currentCarIndex}");

                }
                else if (zPossible)
                {
                    zOccupied = currentCar;
                    zRemainingGas -= currentCar;
                    currentCarIndex++;
                    Logger.Log(2, $"zPossible {zPossible} ");
                    Logger.Log(2, $"zOccupied {zOccupied} zRemainingGas {zRemainingGas} currentCarIndex {currentCarIndex}");

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
                    Logger.Log(2, $"minWaitTime {minWaitTime} time {time} xOccupied {zOccupied} zOccupied {zOccupied} zOccupied {zOccupied}");
                }
            }
            Logger.Flush();
            return time;
        }
    }
}
