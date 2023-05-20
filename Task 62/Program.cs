/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/



void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],6:F0}");
        }
        Console.WriteLine();
    }
}

void MakeItSknake(int[,] array)
{
    int curElement = 0;

    int size = array.GetLength(0);
    int NumberOfLoops = size / 2 + 1;

    for (int n = 0; n < NumberOfLoops; n++)
    {
        for (int i1 = n; i1 < size - n; i1++)
        {
            curElement++;
            array[n, i1] = curElement;
        }
        for (int j1 = n + 1; j1 < size - n; j1++)
        {
            curElement++;
            array[j1, size - n - 1] = curElement;
        }
        for (int i2 = size - n - 2; i2 > 0 + n; i2--)
        {
            curElement++;
            array[size - n - 1, i2] = curElement;
        }
        for (int j2 = size - n - 1; j2 > 0 + n; j2--)
        {
            curElement++;
            array[j2, n] = curElement;
        }
    }
}

int size = 11;

int[,] array = new int[size, size];
MakeItSknake(array);
PrintArray(array);
