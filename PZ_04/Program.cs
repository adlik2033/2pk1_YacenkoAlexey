namespace PZ_04
{
internal class Program
{
    static void Main(string[] args)
    {
        {
            Console.WriteLine("Начало решения задач");
            {
                // Задача 1
                Console.WriteLine("Задача 1");
                int i;
                for (i = -100; i <= 20; i += 3)
                    Console.WriteLine(i);
            }

            {
                // Задача 2
                Console.WriteLine("Задача 2");
                {
                    int j;
                    char startChar = 'п';
                    for (j = 0; j < 10; j++)
                    {
                        Console.Write(startChar);
                        startChar++;
                    }
                    Console.WriteLine();

                }
            }

            {
                // Задача 3
                Console.WriteLine("Задача 3");
                {
                    int l;
                    for (l = 0; l < 3; l++)
                    {
                        int n;
                        for (n = 0; n < 10; n++)
                        {
                            Console.Write("#");
                        }
                        Console.WriteLine();
                    }
                }
            }

            {
                // Задача 4
                Console.WriteLine("Задача 4");
                {
                    int count = 0;
                    {
                        int h;
                        for (h = -300; h <= 200; h++)
                        {
                            if (h % 6 == 0)
                            {
                                Console.WriteLine(h + "");
                                count++;
                            }

                        }
                    }
                }
            }

            {
                //Задача 5
                Console.WriteLine("Задача 5");

                {
                    int g = 2;
                    int b = 30;

                    for (; Math.Abs(g - b) != 6; g++, b--)
                    {
                        Console.WriteLine("g и b: {0} и {1}", g, b);
                    }

                    Console.WriteLine("Итоговые значения с необходимой разницей: g и b: {0} и {1}", g, b);
                }
            }

            Console.WriteLine("Конец решения задач");
        }
    }
}
}
