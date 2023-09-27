namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение задачи 29");
            Console.WriteLine("Начало одномерного массива");
            // Создаем и заполняем массив случайными числами и выводим его
            int[] array = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-101, 101);
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("Конец одномерного массива");


            // Находим сумму положительных элементов
            int sum = 0;
            foreach (int num in array)
            {
                if (num > 0)
                    sum += num;
            }

            // Если сумма меньше 10, добавляем максимальный положительный элемент
            int q = int.MinValue;
            foreach (int num in array)
            {
                if (num > q)
                    q = num;
            }
            if (sum < 10)
                sum += q;

            Console.WriteLine("Сумма положительных элементов: " + sum);
            Console.WriteLine("Конец решения задачи");
        }
    }
}