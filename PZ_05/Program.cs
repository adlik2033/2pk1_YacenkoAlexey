namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Определение n-ого числа Фибоначчи φn"); // Поставленная задача
            Console.Write("Введите число n: ");
            // Вводим число n
            int n = int.Parse(Console.ReadLine());

            // Вводим все нужные нам переменные
            int a = 0; // Текущее число Фибоначчи
            int b = 1; // Предыдущее число Фибоначчи
            int c = 0; // Счетчик

            while (c < n)  // Сам цикл while
            {
                // Здесь мы обновляем значения a и b, а затем прибавляем к c единицу
                // d еще одна помогающая переменная
                int d = a;
                a = b + a;
                b = d;
                c++;
                // Цикл выполняется до тех пор, пока значение c не достигнет значения n
            }
            Console.WriteLine($"{n}-ое число Фибоначчи: {a}");
        }
    }
}