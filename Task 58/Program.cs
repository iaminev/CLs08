/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

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
}

int[,] MultiplyArrays(int[,] A, int[,] B)
{
    int[,] AXB = new int[A.GetLength(0), B.GetLength(1)];
    for (int i = 0; i < A.GetLength(0); i++)
    {
        for (int j = 0; j < B.GetLength(1); j++)
        {
            for (int r = 0; r < A.GetLength(1); r++)
            {
                AXB[i, j] += A[i, r] * B[r, j];
            }

        }
    }
    return AXB;
}

// Матрицы A и B могут быть перемножены, если они совместимы в том смысле, что число столбцов матрицы A равно числу строк B
int rowsA = 4;
int colsA = 5;
int rowsB = colsA;
int colsB = 3;

int[,] arrayA = new int[rowsA, colsA];
FillArray(arrayA, minValue: 0, maxValue: 9);
PrintArray(arrayA);
System.Console.WriteLine("X");

int[,] arrayB = new int[rowsB, colsB];
FillArray(arrayB, minValue: 0, maxValue: 9);
PrintArray(arrayB);
System.Console.WriteLine("=");

int[,] arrayAXarrayB = MultiplyArrays(arrayA, arrayB);
PrintArray(arrayAXarrayB);