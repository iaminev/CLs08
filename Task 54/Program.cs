/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/

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
            Console.Write($"{array[i, j],3:F0}");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void SortDescending(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j1 = 0; j1 < array.GetLength(1); j1++)
        {
            for (int j2 = 0; j2 < array.GetLength(1); j2++)
            {
                if (array[i, j1] > array[i, j2])
                {
                    int temp = array[i, j1];
                    array[i, j1] = array[i, j2];
                    array[i, j2] = temp;
                }
            }
        }
    }
}

int rows = 5;
int cols = 5;
int[,] array = new int[rows, cols];
FillArray(array, maxValue: 9);
System.Console.WriteLine("Initial array:");
PrintArray(array);
SortDescending(array);
System.Console.WriteLine("After sorting elements in each line DESC:");
PrintArray(array);
