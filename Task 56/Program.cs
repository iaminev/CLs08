/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

void FillArray(int[,] array, int minValue = 0, int maxValue = 10)
{
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],4:F0}");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int FindRowWithMinSumOfElements(int[,] array)
{
    int minRow = 0;
    int minSum = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        minSum += array[0, j];
    }

    for (int i = 1; i < array.GetLength(0); i++)
    {
        int sumOfElements = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumOfElements += array[i, j];
        }
        if (minSum > sumOfElements)
        {
            minSum = sumOfElements;
            minRow = i;
        }
    }
    return minRow + 1;
}

int rows = 5;
int cols = 5;
int[,] array = new int[rows, cols];
FillArray(array, minValue: -9, maxValue: 9);
System.Console.WriteLine("Initial array:");
PrintArray(array);
System.Console.WriteLine($"The number of row with min.sum of elements: {FindRowWithMinSumOfElements(array)}");
