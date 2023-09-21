namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ввеедите действительное число a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Ввеедите целое число число с: ");
            int c = int.Parse(Console.ReadLine());
            // Вводим 2 переменные типа int и double, как сказано в задании

            {
                double x, y, z;
                // Вводим еще 3 нужные нам переменные double
                {
                    if (a > Math.PI) // Условие
                    {
                        x = Math.Cos(a + 2 * c); // Вычисления
                    }
                    else // Если условие выше не выполняется, то берем этот вариант
                    {
                        x = c + Math.Sqrt(a * Math.Pow(c, 2) - 2 * (a + Math.PI)); // Вычисления
                    }
                    Console.WriteLine($"Значение x: {x} "); // Выводим ответ 1
                }

                {
                    if (x <= 0) // Условие
                    {
                        y = Math.Log(a + c - x); // Вычисления
                    }
                    else // Если условие выше не выполняется, то берем этот вариант
                    {
                        y = (Math.Sin(2 * a * x)) + Math.Sin(a + x); // Вычисления
                    }
                    Console.WriteLine($"Значение y: {y}"); // Выводим ответ 2

                }

                {
                    z = ((2 * x + 3 * y) * (Math.Pow(a, 2) - Math.Pow(c, 2))); // Итоговые выражение со всеми нужными нам переменными
                }
                Console.WriteLine($"Значение z: {z}"); // Выводим ответ 3
            }
        }
    }
}

