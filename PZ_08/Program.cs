namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание ступенчатого массива (1 изм. 50, 2 изм. random 10-20, заполнение random)");
            Console.WriteLine("|||________________________________________________________________________________|||");
            int[][] array = new int[50][]; 
            // Cоздание массива с длинной первого измерения 50
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int a2Length = rnd.Next(10, 21); // Генерация случайной длины второго измерения
                array[i] = new int[a2Length];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(1,1000); // Генерация случайного целого числа
                }
            }

            // Вывод элементов массива на экран
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("|||________________________________________________________________________________|||");


            //*Создать новый одномерный массив нужной и записать
            //в него последние элементы каждой строки. Вывести данный массив.*//
            Console.WriteLine("Задача 1 по заданному ступенчатому массиву");
            Console.WriteLine("|||________________________________________________________________________________|||");
            for (int i = 0; i < array.Length; i++)
            {
                int lastIndex = array[i].Length - 1;
                // Пишем a{i].L - 1 потому что индексы массивов начинаются с 0,
                // поэтому для получения последнего элемента нужно писать - 1
                int lastElement = array[i][lastIndex];
                Console.WriteLine("Последний элемент строки {0}: {1}", i, lastElement);
            }
            Console.WriteLine("|||________________________________________________________________________________|||");


            //*В каждой строке ступенчатого найти максимальный элемент,
            //записать их в другой массив (новый или повторно использовать предыдущий)
            //и вывести его содержимое.*//
            Console.WriteLine("Задача 2 по заданному массиву");
            Console.WriteLine("|||________________________________________________________________________________|||");
            int[] maxElements = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int maxElement = 0; // Максимальный элемент начинаем с нуля

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > maxElement)
                    {
                        maxElement = array[i][j];
                    }
                }

                maxElements[i] = maxElement; // Сохраняем максимальный элемент в новом массиве
            }

            // Вывод содержимого нового массива
            for (int i = 0; i < maxElements.Length; i++)
            {
                Console.WriteLine("Максимальный элемент строки {0}: {1}", i, maxElements[i]);
            }
            Console.WriteLine("|||________________________________________________________________________________|||");

            //*В каждой строке исходного массива поменять местами первый элемент и максимальный в строке.
            //Вывести обновленный массив. *//
            Console.WriteLine("Задача 3 по заданному массиву");
            Console.WriteLine("|||________________________________________________________________________________|||");
            for (int i = 0; i < maxElements.Length; i++)
            {
                int b;
                int value = maxElements[i];
                int index = Array.IndexOf(array[i], value); // находим индекс элемента
                b = array[i][0];
                array[i][0] = maxElements[i];
                array[i][index] = b;
            }


            // Выводим итог на экран
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }


            //*Выполнить реверс каждой строки ступенчатого массива*//
            Console.WriteLine("|||________________________________________________________________________________|||");
            Console.WriteLine("Задача 4 по заданному массиву");
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ДЛЯ ПРИВЛЕЧЕНИЯ ВНИМАНИЯ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Тут я перепробовал все, что знал. Не получилось. Даже те же методы пробовал, почему то просто не получается.
            // Пробовал вводить перменные право и лево, чтобы просто менять правые на левые, однако мне
            // выдавало ошибку "Index was outside the bounds of the array.". После этого пробовал вводить диапазон
            // переменных  while (left < right && left < array[i].Length && right >= 0)
            // Тут не получилось.
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!ДЛЯ ПРИВЛЕЧЕНИЯ ВНИМАНИЯ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Console.WriteLine("|||________________________________________________________________________________|||");
            int[] qqq = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int left = 0; // Вводим те самые право и лево
                int right = array[i].Length - 1;

                // Проверяем, что левый индекс и правый индекс находятся в допустимом диапазоне
                while (left < right && left < array[i].Length && right >= 0 && left >= 0)
                {
                    int b; 
                    b = array[i][right];
                    array[i][right] = array[i][left];
                    array[i][left] = b;

                    left++;
                    right--;
                }
            }
            // Выводим итог на экран
            for (int i = 0; i < qqq.Length; i++)
            {
                for (int j = 0; j < qqq.Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("|||________________________________________________________________________________|||");

            //*Подсчитать Среднее значение в каждой строке(для чисел)*//
            Console.WriteLine("Задача 5 по заданному массиву");
            Console.WriteLine("|||________________________________________________________________________________|||");
            double[] average = new double[array.Length]; // Создаем новый массив для средних значений

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                int count = array[i].Length;

                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                average[i] = (double)sum / count; // Вычисляем среднее и сохраняем его в массиве
            }

            // Вывод средних значений
            for (int i = 0; i < average.Length; i++)
            {
                Console.WriteLine("Среднее значение строки {0}: {1}", i, average[i]);
            }
            Console.WriteLine("|||________________________________________________________________________________|||");
        }

    }
    
}