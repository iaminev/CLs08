/*Задача 57: Составить частотный словарь элементов двумерного массива.
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.*/

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

void FillArray1D(int[] array, int minValue = 0, int maxValue = 10)
{
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        array[i] = rnd.Next(minValue, maxValue + 1);
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

void PrintArray1D(int[] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write($"{array[i],3:F0}");
    }
    Console.WriteLine();
}

Dictionary<int, int> CalculateFrequencies(int[] array)
{
    var frequencyDict = new Dictionary<int, int>();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int currentKey = array[i];
        if (frequencyDict.ContainsKey(currentKey))
        {
            frequencyDict[currentKey]++;
        }
        else
        {
            frequencyDict.Add(currentKey, 1);
        }
    }
    return frequencyDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
}

int[] ConvertTo1DArray(int[,] array2D)
{
    int[] result = new int[array2D.Length];
    int ii = 0;
    for (int i = 0; i < array2D.GetLength(0); i++)
    {
        for (int j = 0; j < array2D.GetLength(1); j++)
        {
            result[ii] = array2D[i, j];
            ii++;
        }
    }
    return result;
}

void PrintDictionary(Dictionary<int, int> dict)
{
    foreach (var item in dict)
    {
        System.Console.WriteLine($"{item.Key} is found {item.Value} time(s)");
    }
}

int rows = 5;
int cols = 5;
int[,] array = new int[rows, cols];
FillArray(array, maxValue: 9);
PrintArray(array);
Dictionary<int, int> frequencyDict = CalculateFrequencies(ConvertTo1DArray(array));
PrintDictionary(frequencyDict);

System.Console.WriteLine();
int elements1D = 25;
int[] array1D = new int[elements1D];
FillArray1D(array1D, maxValue: 9);
PrintArray1D(array1D);
PrintDictionary(CalculateFrequencies(array1D));