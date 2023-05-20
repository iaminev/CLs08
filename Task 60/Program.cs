/*Задача 60. 
...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, 
добавляя индексы каждого элемента.

Массив размером 2 x 2 x 2
66(0,0,0) 25(0, 1, 0)
34(1, 0, 0) 41(1, 1, 0)
27(0, 0, 1) 90(0, 1, 1)
26(1, 0, 1) 55(1, 1, 1)*/

bool ValueExistsInArray(int[,,] array, int value)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value)
                {
                    return true;
                }
            }
        }
    }
    return false;
}

void FillArrayUniqueNumbers(int[,,] array, int minValue = 0, int maxValue = 10)
{
    var rnd = new Random();
    int triesCount = 0;
    int epoch = 0;
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                epoch++;
                bool valueOK = false;
                int curTries = 0;
                while (!valueOK)
                {
                    int curValue = rnd.Next(minValue, maxValue + 1);
                    if (!ValueExistsInArray(array, curValue) && (curValue < -9 || curValue > 9))
                    {
                        valueOK = true;
                        array[i, j, k] = curValue;
                    }
                    triesCount++;
                    curTries++;
                }
                if (curTries > 1)
                {
                    System.Console.WriteLine($"Element {epoch}: number of tries = {curTries}");
                }
            }
        }
    }
    System.Console.WriteLine($"The 3D array of {array.GetLength(0) * array.GetLength(1) * array.GetLength(2)} unique elements is filled in {triesCount} tries");
}

void PrintArray3D(int[,,] array)
{
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j, k],5:F0}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---");
    }
}


int rows = 3;
int cols = 20;
int layers = 3;

if (rows * cols * layers <= 180)
{
    int[,,] array = new int[rows, cols, layers];
    FillArrayUniqueNumbers(array, minValue: -99, maxValue: 99);
    PrintArray3D(array);
}
else
{
    System.Console.WriteLine($"There is no solution, number of elements in this array must be less than or equal to {180}");
}
