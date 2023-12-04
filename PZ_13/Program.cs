namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, x;
            Console.Write("Введите число n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Первая задача");
            Console.WriteLine($"{n}-й член прогрессии равен " + Progress(n));
            Console.WriteLine(" ");
            Console.WriteLine("Вторая задача");
            Console.Write("Введите число x: ");
            x = Convert.ToInt32(Console.ReadLine());
            double firstTerm = 3; // первый член прогрессии
            double commonRatio = 0.15; // знаменатель геометрической прогрессии
            Console.WriteLine($"{x}-й член прогрессии равен " + Progress2(x, firstTerm, commonRatio));
            Console.WriteLine(" ");
            int y = 9;
            int z = -32;
            Console.WriteLine("Третья задача");
            Console.WriteLine("Первое число равно " + y);
            Console.WriteLine("Второе число равно " + z);
            Compare(y, z);
            int a, b;
            Console.WriteLine(" ");
            int number;
            Console.WriteLine("Четвертая задача");
            Console.Write("Введите число: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ReverseNumber(number)); 

        }
        static int Progress(int n)
        {
            int ans = 0;
            if (n == 1)
            {
                return 6;
            }
            else
            {
                ans = Progress(n - 1);
                ans = ans + 3;
            }
            return ans;
        }
        static double Progress2(int x, double firstTerm, double commonRatio)
        {
            if (x == 1)
                return firstTerm;

            double previousTerm = Progress2(x - 1, firstTerm, commonRatio);

            return previousTerm * commonRatio;
        }

        static int Compare(int y, int z)
        {
            if (y + 1 == z)
            {
                return z;
            }
            else
            {
                Console.WriteLine(y);
                y = Compare(y - 1, z);
                y = y - 1;
            }
            return y;
        }
        static int ReverseNumber(int number)
        {
            if (number < 10)
                return number;

            int lastDigit = number % 10;
            int remainingDigits = number / 10;

            int reversed = ReverseNumber(remainingDigits);
            int numberOfDigits = (int)Math.Floor(Math.Log10(remainingDigits) + 1);

            return lastDigit * (int)Math.Pow(10, numberOfDigits) + reversed;
        }
    }
}