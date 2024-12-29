using System;
using System.Collections.Generic;

//Задание 1

//class MyMatrix
//{
//    private int[,] matrix;
//    private Random random = new Random();

//    // Конструктор
//    public MyMatrix(int rows, int cols, int minValue, int maxValue)
//    {
//        matrix = new int[rows, cols];
//        Fill(minValue, maxValue);
//    }

//    // Метод для заполнения матрицы случайными значениями
//    public void Fill(int minValue, int maxValue)
//    {
//        int rows = matrix.GetLength(0);
//        int cols = matrix.GetLength(1);
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                matrix[i, j] = random.Next(minValue, maxValue);
//            }
//        }
//    }

//    // Метод для изменения размера матрицы
//    public void ChangeSize(int newRows, int newCols)
//    {
//        int[,] newMatrix = new int[newRows, newCols];

//        int minRows = Math.Min(newRows, matrix.GetLength(0));
//        int minCols = Math.Min(newCols, matrix.GetLength(1));

//        for (int i = 0; i < minRows; i++)
//        {
//            for (int j = 0; j < minCols; j++)
//            {
//                newMatrix[i, j] = matrix[i, j];
//            }
//        }

//        // Заполняем новую часть матрицы случайными значениями
//        if (newRows > matrix.GetLength(0) || newCols > matrix.GetLength(1))
//        {
//            Fill(0, 100);  // Например, заполняем оставшуюся часть значениями от 0 до 100
//        }

//        matrix = newMatrix;
//    }

//    // Метод для показа части матрицы
//    public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
//    {
//        for (int i = startRow; i <= endRow && i < matrix.GetLength(0); i++)
//        {
//            for (int j = startCol; j <= endCol && j < matrix.GetLength(1); j++)
//            {
//                Console.Write(matrix[i, j] + "\t");
//            }
//            Console.WriteLine();
//        }
//    }

//    // Метод для вывода всей матрицы
//    public void Show()
//    {
//        for (int i = 0; i < matrix.GetLength(0); i++)
//        {
//            for (int j = 0; j < matrix.GetLength(1); j++)
//            {
//                Console.Write(matrix[i, j] + "\t");
//            }
//            Console.WriteLine();
//        }
//    }

//    // Индексатор для доступа к элементам матрицы
//    public int this[int index1, int index2]
//    {
//        get
//        {
//            if (index1 >= 0 && index1 < matrix.GetLength(0) && index2 >= 0 && index2 < matrix.GetLength(1))
//            {
//                return matrix[index1, index2];
//            }
//            throw new IndexOutOfRangeException("Индексы находятся вне диапазона матрицы.");
//        }
//        set
//        {
//            if (index1 >= 0 && index1 < matrix.GetLength(0) && index2 >= 0 && index2 < matrix.GetLength(1))
//            {
//                matrix[index1, index2] = value;
//            }
//            else
//            {
//                throw new IndexOutOfRangeException("Индексы находятся вне диапазона матрицы.");
//            }
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.Write("Введите количество строк: ");
//        int rows = int.Parse(Console.ReadLine());
//        Console.Write("Введите количество столбцов: ");
//        int cols = int.Parse(Console.ReadLine());
//        Console.Write("Введите минимальное значение случайного числа: ");
//        int minValue = int.Parse(Console.ReadLine());
//        Console.Write("Введите максимальное значение случайного числа: ");
//        int maxValue = int.Parse(Console.ReadLine());

//        MyMatrix myMatrix = new MyMatrix(rows, cols, minValue, maxValue);

//        Console.WriteLine("Исходная матрица:");
//        myMatrix.Show();

//        Console.Write("Введите новые размеры (строки): ");
//        int newRows = int.Parse(Console.ReadLine());
//        Console.Write("Введите новые размеры (столбцы): ");
//        int newCols = int.Parse(Console.ReadLine());

//        myMatrix.ChangeSize(newRows, newCols);
//        Console.WriteLine("Обновленная матрица:");
//        myMatrix.Show();

//        Console.Write("Введите начальную строку для показа (включительно): ");
//        int startRow = int.Parse(Console.ReadLine());
//        Console.Write("Введите конечную строку для показа (включительно): ");
//        int endRow = int.Parse(Console.ReadLine());
//        Console.Write("Введите начальный столбец для показа (включительно): ");
//        int startCol = int.Parse(Console.ReadLine());
//        Console.Write("Введите конечный столбец для показа (включительно): ");
//        int endCol = int.Parse(Console.ReadLine());

//        Console.WriteLine("Часть матрицы:");
//        myMatrix.ShowPartialy(startRow, endRow, startCol, endCol);
//    }
//}



// Задание 2

using System;
using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public MyList(params T[] initialValues)
    {
        items = new T[initialValues.Length];
        Array.Copy(initialValues, items, initialValues.Length);
        count = initialValues.Length;
    }

    public MyList(IEnumerable<T> collection)
    {
        items = new T[0];
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = count == 0 ? 4 : count * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }

        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            return items[index];
        }
    }

    public int Count
    {
        get { return count; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };

        myList.Add(678);

        Console.WriteLine($"Our elements i - 1, cheeeeck:\n");
        foreach (var item in myList)
        {
            Console.WriteLine($"Element: {item}");
        }

        Console.WriteLine($"\nTotal number of elements: {myList.Count}");
    }
}


//Задание 3
//using System.Collections;
//using System.Collections.Generic;

//public class MyDictionary<TKey, TValue> : IEnumerable
//{
//    private TKey[] keys;
//    private TValue[] values;
//    private int count;

//    // Конструктор по умолчанию
//    public MyDictionary()
//    {
//        keys = new TKey[4]; // Начальный размер массива
//        values = new TValue[4];
//        count = 0;
//    }

//    // Метод для добавления элемента
//    public void Add(TKey key, TValue value)
//    {
//        if (count == keys.Length)
//        {
//            ResizeArrays();
//        }

//        // Проверка на уникальность ключа
//        for (int i = 0; i < count; i++)
//        {
//            if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
//            {
//                throw new ArgumentException("Ключ уже существует.");
//            }
//        }

//        keys[count] = key;
//        values[count] = value;
//        count++;
//    }

//    // Индексатор для доступа к элементам по ключу
//    public TValue this[TKey key]
//    {
//        get
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
//                {
//                    return values[i];
//                }
//            }
//            throw new KeyNotFoundException("Ключ не найден.");
//        }
//        set
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
//                {
//                    values[i] = value;
//                    return;
//                }
//            }
//            throw new KeyNotFoundException("Ключ не найден.");
//        }
//    }

//    // Свойство для получения общего количества элементов
//    public int Count => count;

//    // Метод для изменения размера массивов
//    private void ResizeArrays()
//    {
//        int newSize = keys.Length * 2;

//        TKey[] newKeys = new TKey[newSize];
//        TValue[] newValues = new TValue[newSize];

//        Array.Copy(keys, newKeys, keys.Length);
//        Array.Copy(values, newValues, values.Length);

//        keys = newKeys;
//        values = newValues;
//    }

//    // Реализация IEnumerable для перебора элементов в цикле foreach
//    public IEnumerator GetEnumerator()
//    {
//        for (int i = 0; i < count; i++)
//        {
//            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
//        }
//    }
//}

//// Класс для представления пары ключ-значение
//public class KeyValuePair<TKey, TValue>
//{
//    public TKey Key { get; }
//    public TValue Value { get; }

//    public KeyValuePair(TKey key, TValue value)
//    {
//        Key = key;
//        Value = value;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        MyDictionary<string, int> myDict = new MyDictionary<string, int>();

//        myDict.Add("one", 1);
//        myDict.Add("two", 2);
//        myDict.Add("three", 3);

//        Console.WriteLine("Количество элементов: " + myDict.Count);

//        foreach (var pair in myDict)
//        {
//            var kvp = (KeyValuePair<string, int>)pair;
//            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
//        }

//        // Изменение значения элемента
//        myDict["two"] = 22;
//        Console.WriteLine($"Обновленное значение для 'two': {myDict["two"]}");
//    }
//}
